using Business.Abstract;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserFavManager : IUserFavService
    {
        IUserFavDal _userFavDal;
        
        public UserFavManager(IUserFavDal userFavDal)
        {
            _userFavDal = userFavDal;   
        }
        public IAsyncResult Add(UserFavDetailDto userFavDetailDto)
        {
            throw new NotImplementedException();
        }
    }
}
