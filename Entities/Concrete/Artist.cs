using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Artist : IEntity
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}
