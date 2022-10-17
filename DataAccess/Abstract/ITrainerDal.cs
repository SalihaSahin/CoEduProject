using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ITrainerDal:IEntityRepository<Trainer>
    {
        List<OperationClaim> GetClaims(Trainer trainer);
        List<TrainerDetailDto> GetTrainerDetails(Expression<Func<Trainer, bool>> filter = null);
 
    }
}
