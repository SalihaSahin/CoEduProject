using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

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

        public List<UserDetailDto> GetUserDetails(Expression<Func<User, bool>> filter = null)
        {
            using (CoEduContext context = new CoEduContext())
            {
                var result = from u in filter == null ? context.Users : context.Users.Where(filter)
                             select new UserDetailDto()
                             {
                                 UserId = u.UserId,
                                 UserName=u.UserName,
                                 UserSurname=u.UserSurname,
                                 UserEmail=u.UserEmail

                             };
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
                                 UserSurname = user.UserSurname,
                                 UserEmail = user.UserEmail
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
