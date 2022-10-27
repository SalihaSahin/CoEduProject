using Core.Entities.Concrete;
using Core.Utitlities.Results;
using Core.Utitlities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITrainerService
    {
        List<OperationClaim> GetClaims(Trainer trainer);
        IDataResult<int> Add(Trainer trainer);
        IResult Delete(Trainer trainer);
        IResult Update(Trainer trainer);
       

        IDataResult<List<Trainer>> GetAll();
        IDataResult<Trainer> GetById(int trainerId);
        IDataResult<TrainerDetailDto> GetTrainerDetailById(int trainerId);
        IDataResult<List<TrainerDetailDto>> GetTrainerDetails();
        IDataResult<List<TrainerDetailDto>> GetAllByAddressId(int addressId);
        IDataResult<List<TrainerDetailDto>> GetAllByFormOfEduId(int formOfEduId);
        IDataResult<List<TrainerDetailDto>> GetAllByEducationId(int educationId);
        IDataResult<List<TrainerDetailDto>> GetAllByFilter(int educationId, int formOfEduId, int addressId);
        Trainer GetByMail(string trainerEmail);

        IDataResult<List<OperationClaim>> GetClaimsByTrainerId(int trainerId);
        IDataResult<TrainerDetailDto> GetTrainerDetailsByEmail(string email);
    }
}
