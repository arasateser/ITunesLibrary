﻿using Business.Abstract;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
            var result = BusinessRules.Run(CheckIfArtistNameExists(artist.Name));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
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

        private IResult CheckIfArtistNameExists(string artistName)
        {
            var result = _artistDal.GetAll(a => a.Name == artistName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ArtistNameExists);
            }
            return new SuccessResult();
        }


    }
}
