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
        IResult Delete(User user);
        IResult Update(User user);
        IResult UpdateUserDto(UserUpdateDto userUpdateDto,  int userId);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        User GetByMail(string userEmail);
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<OperationClaim>> GetClaimsByUserId(int userId);
        IDataResult<UserDetailDto> GetUserDetailsByEmail(string email);
    }
}
