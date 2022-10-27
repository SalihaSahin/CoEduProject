using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utitlities.Results;
using Core.Utitlities.Security.Hashing;
using Core.Utitlities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private ITrainerService _trainerService;
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimsService _userOperationClaimsService;
        private ITrainerOperationClaimService _trainerOperationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ITrainerService trainerService, IUserOperationClaimsService userOperationClaimsService , ITrainerOperationClaimService trainerOperationClaimService )
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _trainerService = trainerService;
            _userOperationClaimsService = userOperationClaimsService;
            _trainerOperationClaimService = trainerOperationClaimService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserEmail = userForRegisterDto.UserEmail,
                UserName = userForRegisterDto.UserName,
                UserSurName = userForRegisterDto.UserSurName,
                UserPasswordHash = passwordHash,
                UserPasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            _userOperationClaimsService.Add(new UserOperationClaim() { UserId = user.UserId, OperationClaimId = 2 });

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.UserEmail);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.UserPassword, userToCheck.UserPasswordHash, userToCheck.UserPasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<Trainer> RegisterTrainer(TrainerForRegisterDto trainerForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var trainer = new Trainer
            {
                TrainerEmail = trainerForRegisterDto.TrainerEmail,
                TrainerName = trainerForRegisterDto.TrainerName,
                TrainerSurname = trainerForRegisterDto.TrainerSurName,
                TrainerPasswordHash = passwordHash,
                TrainerPasswordSalt = passwordSalt,
                Status = true
            };
            _trainerService.Add(trainer);
            _trainerOperationClaimService.Add(new TrainerOperationClaim() { TrainerId = trainer.TrainerId, OperationClaimId = 3 });
            return new SuccessDataResult<Trainer>(trainer, Messages.TrainerRegistered);
        }

        public IDataResult<Trainer> LoginTrainer(TrainerForLoginDto trainerForLoginDto)
        {
            var trainerToCheck = _trainerService.GetByMail(trainerForLoginDto.TrainerEmail);
            if (trainerToCheck == null)
            {
                return new ErrorDataResult<Trainer>(Messages.TrainerNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(trainerForLoginDto.TrainerPassword, trainerToCheck.TrainerPasswordHash, trainerToCheck.TrainerPasswordSalt))
            {
                return new ErrorDataResult<Trainer>(Messages.PasswordError);
            }

            return new SuccessDataResult<Trainer>(trainerToCheck, Messages.SuccessfulLogin);
        }

        public IResult TrainerExists(string email)
        {
            if (_trainerService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.TrainerAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Trainer trainer)
        {
            var claims = _trainerService.GetClaims(trainer);
            var accessToken = _tokenHelper.CreateToken(trainer, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
