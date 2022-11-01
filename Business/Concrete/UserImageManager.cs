using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utitlities.Helpers.FileHelper;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;
        IFileHelper _fileHelper;

        public UserImageManager(IUserImageDal userImageDal, IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
            _userImageDal = userImageDal;
        }
        
        public IResult Add(IFormFile file, UserImage userImage)
        {
            userImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);

            _userImageDal.Add(userImage);
            return new SuccessResult(Messages.UserImageAdded);
        }

        public IResult Delete(IFormFile file, UserImage userImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + userImage.ImagePath);
            _userImageDal.Delete(userImage);
            return new SuccessResult(Messages.UserImageDeleted);
        }

        public IDataResult<List<UserImage>> GetAll()
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(), Messages.UserImageListed);
        }

        [CacheAspect]
        public IDataResult<UserImage> GetById(int userImgId)
        {
            return new SuccessDataResult<UserImage>(_userImageDal.Get(u => u.Id == userImgId));
        }

        public IDataResult<List<UserImageDto>> GetImagesByUserId(int userId)
        {
            var result = _userImageDal.GetUserImageDetails(userImage => userImage.UserId == userId);
            foreach (var userImage in result)
            {
                userImage.ImagePath = _fileHelper.GetByName(PathConstants.ImagesPath + userImage.ImagePath);
            }

            return new SuccessDataResult<List<UserImageDto>>(result, Messages.succeed);
        }

        public IResult Update(IFormFile file, UserImage userImage)
        {
            var userForUpdate = _userImageDal.Get(image => image.UserId == userImage.UserId);
            if (userForUpdate == null)
            {
                return this.Add(file, userImage);
            }
            userForUpdate.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + userImage.ImagePath, PathConstants.ImagesPath);
            _userImageDal.Update(userForUpdate);
            return new SuccessResult(Messages.UserImageUpdated);
        }
    }
}
