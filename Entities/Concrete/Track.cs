using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Track : IEntity
    {
        public int TrackId { get; set; }
        public string? Name { get; set; }
        public string? Composer { get; set; }
        public int Milliseconds { get; set; }

        //public int MediaTypeId { get; set; }

        //public decimal UnitPrice { get; set; }
    }
}
