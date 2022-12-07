using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserFavService
    {
        IAsyncResult Add(UserFavDetailDto userFavDetailDto);
    }
}
