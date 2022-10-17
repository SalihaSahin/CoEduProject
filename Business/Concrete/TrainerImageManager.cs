using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utitlities.Helpers.FileHelper;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class TrainerImageManager:ITrainerImageService
    {
        ITrainerImageDal _trainerImageDal;
        IFileHelper _fileHelper;

        public TrainerImageManager(ITrainerImageDal trainerImageDal, IFileHelper fileHelper)
        {
            _trainerImageDal = trainerImageDal;
             _fileHelper = fileHelper;
        }

        //[ValidationAspect(typeof(TrainerImageValidator))]
        public IResult Add(IFormFile file, TrainerImage trainerImage )
        {
            trainerImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);

            _trainerImageDal.Add(trainerImage);
            return new SuccessResult(Messages.TrainerImageAdded);
        }

        public IResult Delete(TrainerImage trainerImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + trainerImage.ImagePath);
            _trainerImageDal.Delete(trainerImage);
            return new SuccessResult(Messages.TrainerImageDeleted);
        }

        [CacheAspect]
        public IDataResult<List<TrainerImage>> GetAll()
        {

            return new SuccessDataResult<List<TrainerImage>>(_trainerImageDal.GetAll(), Messages.TrainerImageListed);
        }

        [CacheAspect]
        public IDataResult<TrainerImage> GetById(int trainerImgId)
        {
            return new SuccessDataResult<TrainerImage>(_trainerImageDal.Get(t => t.Id == trainerImgId));
        }

        public IDataResult<List<TrainerImageDto>> GetImagesByTrainerId(int trainerId)
        {
            var result = _trainerImageDal.GetTrainerImageDetails(trainerImage => trainerImage.TrainerId == trainerId);
            foreach (var trainerImage in result)
            {
                trainerImage.ImagePath = _fileHelper.GetByName(PathConstants.ImagesPath + trainerImage.ImagePath);
            }
            
            return new SuccessDataResult<List<TrainerImageDto>>(result, Messages.succeed);
        }

        public IResult Update(IFormFile file, TrainerImage trainerImage)
        {
            var trainerForUpdate = _trainerImageDal.Get(image => image.TrainerId == trainerImage.TrainerId);
            trainerForUpdate.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + trainerImage.ImagePath, PathConstants.ImagesPath);
            _trainerImageDal.Update(trainerForUpdate);
            return new SuccessResult(Messages.TrainerImageUpdated);
        }
    }
}
