using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Security.JWT
{
    //Token oluşturularak jwt den bilgileri çekilmesine yarayacak interface
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        AccessToken CreateToken(Trainer trainer, List<OperationClaim> operationClaims);
    }
}
