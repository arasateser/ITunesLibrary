using Business.Abstract;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class TrackManager : ITrackService
    {
        ITrackDal _trackDal;
        ILogger _logger;
        public TrackManager(ITrackDal trackDal)
        {
            _trackDal = trackDal;
        }

        [ValidationAspect(typeof(TrackValidator))]
        public IResult AddTrack(Track track)
        {
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
    }
}
