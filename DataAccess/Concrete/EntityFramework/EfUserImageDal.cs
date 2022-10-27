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
    public class EfUserImageDal : EfEntityRepositoryBase<UserImage, CoEduContext>, IUserImageDal
    {
        public List<UserImageDto> GetUserImageDetails(Expression<Func<UserImage, bool>> filter = null)
        {
            using (CoEduContext context = new CoEduContext())
            {
                var result = from image in filter == null ? context.UserImages : context.UserImages.Where(filter)
                             join u in context.Users
                             on image.UserId equals u.UserId
                             select new UserImageDto
                             {
                                 Id = image.Id,
                                 UserId = u.UserId,
                                 ImagePath = image.ImagePath,

                             };
                return result.ToList();
            }
        }
    }
}
