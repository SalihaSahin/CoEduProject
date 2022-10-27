using Core.Utitlities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IResult Add(IFormFile file, UserImage userImage);
        IResult Delete(IFormFile file,UserImage userImage);
        IResult Update(IFormFile file, UserImage userImage);
        IDataResult<List<UserImage>> GetAll();
        IDataResult<UserImage> GetById(int userImgId);
        IDataResult<List<UserImageDto>> GetImagesByUserId(int userId);
    }
}
