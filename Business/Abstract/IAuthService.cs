using Core.Entities.Concrete;
using Core.Utitlities.Results;
using Core.Utitlities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);

        IDataResult<Trainer> Register(TrainerForRegisterDto trainerForRegisterDto, string password);
        IDataResult<Trainer> Login(TrainerForLoginDto trainerForLoginDto);
        IResult TrainerExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Trainer trainer);
    }
}
