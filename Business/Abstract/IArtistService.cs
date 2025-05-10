using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArtistService
    {
        IDataResult<List<Artist>> GetAllArtists();
        IDataResult<Artist> GetByArtistId(int artistId);
        IResult AddArtist(Artist artist);
    }
}
