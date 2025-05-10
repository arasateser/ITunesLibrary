using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITrackService
    {
        IDataResult<List<Track>> GetAllTracks();
        IDataResult<Track> GetByTrackId();
        IDataResult<List<Track>> GetTracksByMiliseconds(int min, int max);

    }
}
