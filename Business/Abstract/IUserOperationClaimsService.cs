using Core.Entities.Concrete;
using Core.Utitlities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimsService
    {
        IResult Add(UserOperationClaim userOperationClaim);
        IResult AddRange(List<UserOperationClaim> userOperationClaims);

      
    }
}
