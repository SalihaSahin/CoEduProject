using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserFavDal : EfEntityRepositoryBase<UserFav, CoEduContext>, IUserFavDal
    {
        public List<UserFavDetailDto> GetUserFavDetails(Expression<Func<UserFav, bool>> filter = null)
        {
            using (CoEduContext context = new CoEduContext())
            {
                var result = from u in filter == null ? context.UserFavs : context.UserFavs.Where(filter)
                             join t in context.Trainers
                             on u.TrainerId equals t.TrainerId
                             join a in context.Users
                             on u.UserId equals a.UserId
                             join e in context.Educations
                             on u.EducationId equals e.Id
                             
                             select new UserFavDetailDto()
                             {
                                 Id = u.Id,
                                 UserId = a.UserId,
                                 TrainerId = t.TrainerId,
                                 TrainerFullName = t.TrainerName+" "+ t.TrainerSurname,
                                 TrainerBranch= t.TrainerBranch,
                                 EducationName= e.EduName
                                 

                             };
                return result.ToList();
            }
        }
    }
}
