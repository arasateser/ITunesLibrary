using Business.Abstract;
using Core.Utilities.Results.Abstract;
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

        public IDataResult<List<Track>> GetAllTracks()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Track> GetByTrackId()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Track>> GetTracksByMiliseconds(int min, int max)
        {
            throw new NotImplementedException();
        }
    }
}
