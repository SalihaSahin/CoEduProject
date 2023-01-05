using Business.Abstract;
using Business.Constants;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IResult Delete(int id)
        {
            var result = _userFavDal.Get(a => a.Id == id);
            _userFavDal.Delete(result);
            return new SuccessResult(Messages.UserFavDeleted);
        }

        public IDataResult<List<UserFavDetailDto>> GetUserFavDetails()
        {
            return new SuccessDataResult<List<UserFavDetailDto>>(_userFavDal.GetUserFavDetails());
        }
    }
}
