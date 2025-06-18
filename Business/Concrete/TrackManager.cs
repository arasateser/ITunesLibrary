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
    public class TrackManager : ITrackService
    {
        ITrackDal _trackDal;
        ILogger _logger;
        IAlbumService _albumService;
        public TrackManager(ITrackDal trackDal, IAlbumService albumService)
        {
            _trackDal = trackDal;
            _albumService = albumService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(TrackValidator))]
        public IResult AddTrack(Track track)
        {
            var result = BusinessRules.Run(TrackLimitPerAlbumExceeded());

            _trackDal.Add(track);
            return new SuccessResult(Messages.TracksAdded);
        }

        public IResult DeleteTrack(int id)
        {
            var trackToDelete = _trackDal.Get(t => t.TrackId == id);
            return new SuccessResult(Messages.TracksDeleted);
        }

        public IDataResult<List<Track>> GetAllTracks()
        {
            return new SuccessDataResult<List<Track>>(_trackDal.GetAll(), Messages.TracksListed);
        }

        public IDataResult<Track> GetByTrackId(int id)
        {
            return new SuccessDataResult<Track>(_trackDal.Get(p => p.TrackId == id), Messages.TracksListed);
        }

        public IDataResult<List<Track>> GetTracksByMiliseconds(int min, int max)
        {
            return new SuccessDataResult<List<Track>>(_trackDal.GetAll(p => p.Milliseconds > min && p.Milliseconds < max), Messages.TracksListed);
        }

        [ValidationAspect(typeof(TrackValidator))]
        public IResult UpdateTrack(Track track)
        {
            _trackDal.Update(track);
            return new SuccessResult(Messages.TracksUpdated);
        }

        private IResult TrackLimitPerAlbumExceeded() //needs rework
        {
            var result = _albumService.GetAllAlbums();
            int TrackLimitPerAlbum = 3;
            if (result.Data.Count > TrackLimitPerAlbum)
            {
                return new ErrorResult(Messages.TrackLimitPerAlbumExceeded);
            }
            return new SuccessResult();

        }
    }
}