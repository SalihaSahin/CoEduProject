using Core.Utitlities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITrainerImageService
    {
        IResult Add(IFormFile file, TrainerImage trainerImage);
        IResult Delete(IFormFile file, TrainerImage trainerImage);
        IResult Update(IFormFile file, TrainerImage trainerImage);
        IDataResult<List<TrainerImage>> GetAll();
        IDataResult<TrainerImage> GetById(int trainerImgId);
        IDataResult<List<TrainerImageDto>> GetImagesByTrainerId(int trainerId);
    }
}
