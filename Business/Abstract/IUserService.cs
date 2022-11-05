using Core.Utitlities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<int> Add(User user);
        IDataResult<int> Add(UserCreateDto userCreateDto);
        IResult Delete(int id);
        IResult Update(User user);
        //IResult UpdateUserDto(UserUpdateDto userUpdateDto);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<UserDetailDto> GetUserDetailById(int userId);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User>GetByUserMail(string userEmail);
        User GetByMail(string userEmail);
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId);
        IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);
        IResult ChangeUserPassword(ChangeUserPassword changeUserPassword);
    }
}
