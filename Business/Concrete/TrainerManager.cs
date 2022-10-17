using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class TrainerManager:ITrainerService
    {
        ITrainerDal _trainerDal;
         
        public TrainerManager(ITrainerDal trainerDal)
        {
            _trainerDal = trainerDal;
        }

        //[SecuredOperation("admin,trainer")]
        [ValidationAspect(typeof(TrainerValidator))]
        [CacheRemoveAspect("ITrainerService.Get")]
        public IDataResult<int> Add(Trainer trainer)
        {
            _trainerDal.Add(trainer);
            return new SuccessDataResult<int>(trainer.TrainerId, Messages.TrainerAdded);
        }

        [SecuredOperation("admin,trainer")]
        public IResult Delete(Trainer trainer)
        {
            _trainerDal.Delete(trainer);
            return new SuccessResult(Messages.TrainerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Trainer>> GetAll()
        {

            return new SuccessDataResult<List<Trainer>>(_trainerDal.GetAll(), Messages.TrainerListed);
        }
         
        [CacheAspect]
        public IDataResult<Trainer> GetById(int trainerId)
        {
            return new SuccessDataResult<Trainer>(_trainerDal.Get(t => t.TrainerId == trainerId));
        }

        //[SecuredOperation("admin,trainer")]
        [CacheRemoveAspect("ITrainerService.Get")]
        public IResult Update(Trainer trainer)
        {
            _trainerDal.Update(trainer);
            return new SuccessResult(Messages.TrainerUpdated);
        }

        public IDataResult<List<TrainerDetailDto>> GetTrainerDetails()
        {
          
            return new SuccessDataResult<List<TrainerDetailDto>>(_trainerDal.GetTrainerDetails());
        }

        public IDataResult<List<TrainerDetailDto>>GetAllByAddressId(int addressId)
        {
            return new SuccessDataResult<List<TrainerDetailDto>>(_trainerDal.GetTrainerDetails(t=>t.AddressId==addressId).ToList());
        }

        public IDataResult<List<TrainerDetailDto>> GetAllByFormOfEduId(int formOfEduId)
        {
            return new SuccessDataResult<List<TrainerDetailDto>>(_trainerDal.GetTrainerDetails(t =>t.FormOfEduId==formOfEduId).ToList());
        }

        public IDataResult<List<TrainerDetailDto>> GetAllByEducationId(int educationId)
        {
            return new SuccessDataResult<List<TrainerDetailDto>>(_trainerDal.GetTrainerDetails(t => t.EducationId == educationId).ToList());
        }

        public IDataResult<List<TrainerDetailDto>> GetAllByFilter(int educationId, int formOfEduId, int addressId)
        {
            return new SuccessDataResult<List<TrainerDetailDto>>(_trainerDal.GetTrainerDetails(t => t.EducationId == educationId && t.FormOfEduId == formOfEduId && t.AddressId==addressId).ToList());
        }

        public IDataResult<TrainerDetailDto> GetTrainerDetailById(int trainerId)
        {
            return new SuccessDataResult<TrainerDetailDto>(_trainerDal.GetTrainerDetails(t => t.TrainerId == trainerId).Single());
        }

        public List<OperationClaim> GetClaims(Trainer trainer)
        {
            return _trainerDal.GetClaims(trainer);
        }

        public Trainer GetByMail(string trainerEmail)
        {
            return   _trainerDal.Get(t => t.TrainerEmail == trainerEmail);
        }
    }
}
