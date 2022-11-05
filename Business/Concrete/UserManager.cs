
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utitlities.Results;
using Core.Utitlities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IUserOperationClaimsService _userOperationClaimsService;

        public UserManager(IUserDal userDal, IUserOperationClaimsService userOperationClaimsService)

        {
            _userDal = userDal;
            _userOperationClaimsService = userOperationClaimsService;
        }

        //[ValidationAspect(typeof(UserValidator))]
        public IDataResult<int> Add(User user)
        {
            _userDal.Add(user);
            _userOperationClaimsService.Add(new UserOperationClaim() { UserId = user.UserId, OperationClaimId = 2 });
            return new SuccessDataResult<int>(user.UserId, Messages.UserAdded);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public IDataResult<User> GetByUserMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserEmail == email));
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.UserEmail == email);
        }
        public IResult Delete(int id)
        {
            var result = _userDal.Get(u => u.UserId == id);
            _userDal.Delete(result);
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
        //[SecuredOperation("admin,user")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
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

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }


        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IDataResult<int> Add(UserCreateDto userCreateDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userCreateDto.UserPassword, out passwordHash, out passwordSalt);
            User userForCreate = MapToUser(userCreateDto, passwordHash, passwordSalt);
            _userDal.Add(userForCreate);
            _userOperationClaimsService.Add(new UserOperationClaim() { UserId = userCreateDto.UserId, OperationClaimId = 2 });
            return new SuccessDataResult<int>(userForCreate.UserId, Messages.UserAdded);
        }
        private User MapToUser(UserCreateDto userCreateDto, byte[] passwordHash, byte[] passwordSalt)
        {
            return new User
            {

                UserId = userCreateDto.UserId,
                UserName = userCreateDto.UserName,
                UserSurname = userCreateDto.UserSurname,
                UserEmail = userCreateDto.UserEmail,
                UserPasswordHash = passwordHash,
                UserPasswordSalt = passwordSalt,
                Status = true,
            };
        }

        public IDataResult<UserDetailDto> GetUserDetailById(int userId)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetails(u => u.UserId == userId).Single());
        }

        public IResult ChangeUserPassword(ChangeUserPassword changeUserPassword)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = GetByUserMail(changeUserPassword.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(changeUserPassword.OldPassWord, userToCheck.Data.UserPasswordHash, userToCheck.Data.UserPasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(changeUserPassword.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.Data.UserPasswordHash = passwordHash;
            userToCheck.Data.UserPasswordSalt = passwordSalt;
            _userDal.Update(userToCheck.Data);
            return new SuccessResult(Messages.passwordChanged);

        }
    }
}
