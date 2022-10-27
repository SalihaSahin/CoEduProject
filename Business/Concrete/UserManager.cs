
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager: IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        //[ValidationAspect(typeof(UserValidator))]
        public IDataResult<int> Add(User user)
        {
            _userDal.Add(user);
            return new SuccessDataResult<int>(user.UserId,Messages.UserAdded);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.UserEmail == email);
        }
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        [CacheAspect]
        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UpdateUserDto(UserUpdateDto userUpdateDto , int userId)
        {
            var userForUpdate = GetById(userId).Data;
            userForUpdate.UserName = userUpdateDto.UserName;
            userForUpdate.UserSurName = userUpdateDto.UserSurName;
            userForUpdate.UserEmail = userUpdateDto.UserEmail;
            _userDal.Update(userForUpdate);
            return new SuccessResult();
        }

        public IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId)
        {
            User user = _userDal.Get(u => u.UserId == userId);
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<UserDetailDto> GetUserDetailsByEmail(string email)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetailsByEmail(email));
        }
    }
}
