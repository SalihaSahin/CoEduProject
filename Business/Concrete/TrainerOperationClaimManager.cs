using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TrainerOperationClaimManager : ITrainerOperationClaimService
    {
        private readonly ITrainerOperationClaimDal _trainerOperationClaimDal;

        public TrainerOperationClaimManager(ITrainerOperationClaimDal trainerOperationClaimDal)
        {
            _trainerOperationClaimDal = trainerOperationClaimDal;
        }

        public IResult Add(TrainerOperationClaim trainerOperationClaim)
        {
            _trainerOperationClaimDal.Add(trainerOperationClaim);
            return new SuccessResult();
        }

        public IResult AddRange(List<TrainerOperationClaim> trainerOperationClaims)
        {
            trainerOperationClaims.ForEach(claim =>
            {
                _trainerOperationClaimDal.Add(claim);

            });
            return new SuccessResult();
        }
    }
}
