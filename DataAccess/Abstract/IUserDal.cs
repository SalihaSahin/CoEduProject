using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        UserDetailDto GetUserDetailsByEmail(string email);
    }
}
