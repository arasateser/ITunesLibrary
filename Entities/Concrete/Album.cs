using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Album : IEntity
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
    }
}
