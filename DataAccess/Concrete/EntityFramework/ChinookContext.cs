﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ChinookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;
                Database=Chinook;
                Trusted_Connection=true");
        }
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Track> Track { get; set; }
    }
}
