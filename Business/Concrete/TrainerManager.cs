using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utitlities.Results;
using Core.Utitlities.Security.Hashing;
using Core.Utitlities.Security.JWT;
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
        ITrainerOperationClaimService _trainerOperationClaimService;
        public TrainerManager(ITrainerDal trainerDal  ,ITrainerOperationClaimService trainerOperationClaimService)
        {
            _trainerDal = trainerDal;
            _trainerOperationClaimService = trainerOperationClaimService;
        }

        //[SecuredOperation("admin,trainer")]
        [ValidationAspect(typeof(TrainerValidator))]
        [CacheRemoveAspect("ITrainerService.Get")]
        public IDataResult<int> Add(Trainer trainer)
        {
            _trainerDal.Add(trainer);
            _trainerOperationClaimService.Add(new TrainerOperationClaim() { TrainerId = trainer.TrainerId, OperationClaimId = 3 });
            return new SuccessDataResult<int>(trainer.TrainerId, Messages.TrainerAdded);
        }

        [ValidationAspect(typeof(TrainerValidator))]
        [CacheRemoveAspect("ITrainerService.Get")]
        public IDataResult<int> Add(TrainerCreateDto trainer)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(trainer.TrainerPassword, out passwordHash, out passwordSalt);
            Trainer trainerForCreate = MapToTrainer(trainer, passwordHash, passwordSalt);
            _trainerDal.Add(trainerForCreate);
            _trainerOperationClaimService.Add(new TrainerOperationClaim() { TrainerId = trainer.TrainerId, OperationClaimId = 3 });
            return new SuccessDataResult<int>(trainerForCreate.TrainerId, Messages.TrainerAdded);
        }

        private Trainer MapToTrainer(TrainerCreateDto trainer, byte[] passwordHash, byte[] passwordSalt)
        {
            return new Trainer
            {
                TrainerId = trainer.TrainerId,
                AddressId = trainer.AddressId,
                AboutLessInfo = trainer.AboutLessInfo,
                EducationId = trainer.EducationId,
                FormOfEduId = trainer.FormOfEduId,
                Status = true,
                TrainerAbout = trainer.TrainerAbout,
                TrainerBranch = trainer.TrainerBranch,
                TrainerDate = trainer.TrainerDate,
                TrainerEmail = trainer.TrainerEmail,
                TrainerGender = trainer.TrainerGender,
                TrainerName = trainer.TrainerName,
                TrainerPasswordHash = passwordHash,
                TrainerPasswordSalt = passwordSalt,
                TrainerPhone = trainer.TrainerPhone,
                TrainerSchool = trainer.TrainerSchool,
                TrainerSurname = trainer.TrainerSurname,
                TrainerWage = trainer.TrainerWage
            };
        }

       // [SecuredOperation("admin")]
        public IResult Delete(int id)
        {
            var result = _trainerDal.Get(t => t.TrainerId == id);
            _trainerDal.Delete(result);
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

        public IDataResult<List<OperationClaim>> GetClaimsByTrainerId(int trainerId)
        {
            Trainer trainer = _trainerDal.Get(t => t.TrainerId == trainerId);
            return new SuccessDataResult<List<OperationClaim>>(_trainerDal.GetClaims(trainer));
        }

        public IDataResult<TrainerDetailDto> GetTrainerDetailsByEmail(string email)
        {
            return new SuccessDataResult<TrainerDetailDto>(_trainerDal.GetTrainerDetailsByEmail(email));
        }

        public IDataResult<Trainer> GetByTrainerMail(string trainerEmail)
        {
            return new SuccessDataResult<Trainer>(_trainerDal.Get(t => t.TrainerEmail == trainerEmail));
        }

        public IResult ChangeTrainerPassword(ChangeTrainerPassword changeTrainerPassword)
        {
            byte[] passwordHash, passwordSalt;
            var trainerToCheck = GetByTrainerMail(changeTrainerPassword.TrainerEmail);
            if (trainerToCheck.Data == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(changeTrainerPassword.OldPassWord, trainerToCheck.Data.TrainerPasswordHash, trainerToCheck.Data.TrainerPasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(changeTrainerPassword.NewPassword, out passwordHash, out passwordSalt);
            trainerToCheck.Data.TrainerPasswordHash = passwordHash;
            trainerToCheck.Data.TrainerPasswordSalt = passwordSalt;
            _trainerDal.Update(trainerToCheck.Data);
            return new SuccessResult(Messages.passwordChanged);
        }
    }
}
