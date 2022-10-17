using Core.Entities.Concrete;
using Core.Utitlities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITrainerOperationClaimService
    {
        IResult Add(TrainerOperationClaim trainerOperationClaim);
        IResult AddRange(List<TrainerOperationClaim> trainerOperationClaims);
    }
}
