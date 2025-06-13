using Business.Abstract;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.Error;
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
        ILogger _logger;


        public AlbumManager(IAlbumDal albumDal)
        {
            _albumDal = albumDal;
        }

        [ValidationAspect(typeof(AlbumValidator))]
        public IResult AddAlbum(Album album)
        {
            var result = BusinessRules.Run(IsArtistReachedAlbumLimit(album.ArtistId));
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
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

        IResult IAlbumService.DeleteAlbum(int albumId)
        {
            var albumToDelete = _albumDal.Get(a => a.AlbumId == albumId);
            _albumDal.Delete(albumToDelete);

            return new SuccessResult(Messages.AlbumDeleted);
        }

        [ValidationAspect(typeof(AlbumValidator))]
        IResult IAlbumService.UpdateAlbum(Album album)
        {
            _albumDal.Update(album);
            return new SuccessResult(Messages.AlbumUpdated);
        }

        private IResult IsArtistReachedAlbumLimit(int artistId)
        {
            var result = _albumDal.GetAll(a => a.ArtistId == artistId);
            int maxAlbumCountPerArtist = 2;
            if (result.Count > maxAlbumCountPerArtist)
            {
                return new ErrorResult(Messages.AlbumLimitPerArtistReached);
            }
            return new SuccessResult();
        }
    }
}
