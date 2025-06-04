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
    public class ArtistManager : IArtistService
    {
        IArtistDal _artistDal;

        public ArtistManager(IArtistDal artistDal)
        {
            _artistDal = artistDal;
        }

        public IResult AddArtist(Artist artist)
        {
            _artistDal.Add(artist);
            return new SuccessResult(Messages.ArtistAdded);
        }

        public IResult DeleteArtist(int artistId)
        {
            var artistToDelete = _artistDal.Get(a => a.ArtistId == artistId);
            _artistDal.Delete(artistToDelete);
            return new SuccessResult(Messages.ArtistDeleted);
        }

        public IDataResult<List<Artist>> GetAllArtists()
        {
            return new SuccessDataResult<List<Artist>>(_artistDal.GetAll(), Messages.ArtistsListed);

        }

        public IDataResult<Artist> GetByArtistId(int artistId)
        {
            return new SuccessDataResult<Artist>(_artistDal.Get(a => a.ArtistId == artistId));

        }

        public IResult UpdateArtist(Artist artist)
        {
            _artistDal.Update(artist);
            return new SuccessResult(Messages.ArtistUpdated);
        }
    }
}
