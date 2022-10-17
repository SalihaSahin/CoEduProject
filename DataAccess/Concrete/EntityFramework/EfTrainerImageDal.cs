using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTrainerImageDal: EfEntityRepositoryBase<TrainerImage,CoEduContext>, ITrainerImageDal
    {
        public List<TrainerImageDto> GetTrainerImageDetails(Expression<Func<TrainerImage, bool>> filter = null)
        {

            using (CoEduContext context = new CoEduContext())
            {
                var result = from image in filter == null ? context.TrainerImages : context.TrainerImages.Where(filter)
                             join t in context.Trainers
                             on image.TrainerId equals t.TrainerId
                             select new TrainerImageDto
                             {
                                 Id = image.Id,
                                 TrainerId = t.TrainerId,
                                 ImagePath = image.ImagePath,
                                
                             };
                return result.ToList();
            }
        }
    }
}
