using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AlbumManager : IAlbumService
    {
        IAlbumDal _albumDal;

        public AlbumManager(IAlbumDal albumDal)
        {
            _albumDal = albumDal;
        }

        public IResult AddAlbum(Album album)
        {
            _albumDal.Add(album);
            return new SuccessResult(Messages.AlbumAdded);
        }

        public IDataResult<List<Album>> GetAllAlbums()
        {
            return new SuccessDataResult<List<Album>>(_albumDal.GetAll(), Messages.AlbumsListed);
        }

        public IDataResult<Album> GetByAlbumId(int albumId)
        {
            return new SuccessDataResult<Album>(_albumDal.Get
                (a => a.AlbumId == albumId), Messages.AlbumsListed);

        }
    }
}
