using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CoEduContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CoEduContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserDetailDto GetUserDetailsByEmail(string email)
        {
            using (var context = new CoEduContext())
            {
                var result = from user in context.Users.Where(u => u.UserEmail == email)
                             select new UserDetailDto
                             {
                                 UserId = user.UserId,
                                 UserName = user.UserName,
                                 UserSurName = user.UserSurName,
                                 UserEmail = user.UserEmail
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
