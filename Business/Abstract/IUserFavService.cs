using Core.Utitlities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserFavService
    {
        IResult Delete(int id);

        IDataResult<List<UserFavDetailDto>> GetUserFavDetails();
    }
}
