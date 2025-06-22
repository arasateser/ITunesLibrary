using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection; // <-- You need to add this using statement for BindingFlags

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            // Ensure ServiceTool.ServiceProvider is properly initialized in Program.cs
            // (e.g., ServiceTool.Create(app.Services); after app.Build())
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();

            // *** IMPORTANT: Defensive check for _memoryCache itself ***
            // If IMemoryCache could not be resolved, this indicates a critical DI setup issue.
            // This would cause NREs in other methods like Add, Get, Remove if _memoryCache is null.
            if (_memoryCache == null)
            {
                throw new InvalidOperationException("IMemoryCache could not be resolved by ServiceTool.ServiceProvider. Ensure IMemoryCache is registered and ServiceTool is initialized correctly in Program.cs.");
            }
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Add(string key, object data, int duration)
        {
            _memoryCache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            // --- WARNING: This method uses reflection on internal APIs of MemoryCache. ---
            // --- This approach is fragile and highly discouraged for production code. ---
            // --- It can break with .NET updates without notice. ---

            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty(
                "EntriesCollection",
                BindingFlags.NonPublic | BindingFlags.Instance // Ensure BindingFlags is used
            );

            // *** NULL CHECK 1: Check if the PropertyInfo itself was found ***
            if (cacheEntriesCollectionDefinition == null)
            {
                Console.WriteLine("Warning: Internal 'EntriesCollection' property not found on MemoryCache. Cannot remove by pattern safely.");
                // Consider logging this warning properly or throwing a specific exception.
                return; // Cannot proceed if the internal property isn't found
            }

            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;

            // *** NULL CHECK 2: Check if the retrieved collection is null ***
            if (cacheEntriesCollection == null)
            {
                Console.WriteLine("Warning: Internal 'EntriesCollection' value is null. Cannot remove by pattern.");
                // Consider logging this warning properly.
                return; // Cannot proceed if the collection itself is null
            }

            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            // Iterate through the cache entries using dynamic access
            foreach (var cacheItem in cacheEntriesCollection) // This is your problematic line 48
            {
                // *** NULL CHECK 3: Defensive check for cache item value ***
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                if (cacheItemValue != null)
                {
                    cacheCollectionValues.Add(cacheItemValue);
                }
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // *** NULL CHECK 4: Defensive check for d.Key before ToString() ***
            var keysToRemove = cacheCollectionValues
                                .Where(d => d.Key != null && regex.IsMatch(d.Key.ToString()))
                                .Select(d => d.Key)
                                .ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}