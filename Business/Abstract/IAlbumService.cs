using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAlbumService
    {
        IDataResult<List<Album>> GetAllAlbums();
        IDataResult<Album> GetByAlbumId(int id);
        IResult AddAlbum(Album album);
        IResult DeleteAlbum(int id);
        IResult UpdateAlbum(Album album);
    }
}
