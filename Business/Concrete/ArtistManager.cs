using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
        ILogger _logger;


        public ArtistManager(IArtistDal artistDal)
        {
            _artistDal = artistDal;
        }

        [ValidationAspect(typeof(ArtistValidator))]
        public IResult AddArtist(Artist artist)
        {
            //ValidationTool.Validate(new ArtistValidator(), artist);
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

        [ValidationAspect(typeof(ArtistValidator))]
        public IResult UpdateArtist(Artist artist)
        {
            _artistDal.Update(artist);
            return new SuccessResult(Messages.ArtistUpdated);
        }
    }
}
