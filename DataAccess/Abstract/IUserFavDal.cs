using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserFavDal : IEntityRepository<UserFav>
    {
        List<UserFavDetailDto> GetUserDetails(Expression<Func<UserFav, bool>> filter = null);
    }
}
