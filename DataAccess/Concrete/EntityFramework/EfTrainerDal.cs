using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
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
    public class EfTrainerDal: EfEntityRepositoryBase<Trainer,CoEduContext>,ITrainerDal
    {
        public List<OperationClaim> GetClaims(Trainer trainer)
        {
            using (CoEduContext context = new CoEduContext())
            {
                var result = 

                             from operationClaim in context.OperationClaims
                             join trainerOperationClaim in context.TrainerOperationClaims
                             on operationClaim.Id equals trainerOperationClaim.OperationClaimId
                             where trainerOperationClaim.TrainerId == trainer.TrainerId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
              
                return result.ToList();
            }
        }

        public List<TrainerDetailDto> GetTrainerDetails(Expression<Func<Trainer, bool>> filter = null)
        {
            using (CoEduContext context = new CoEduContext())
            {
                var result = from t in filter == null ? context.Trainers : context.Trainers.Where(filter)
                             join a in context.Addresses
                             on t.AddressId equals a.Id
                             join f in context.FormOfEdus
                             on t.FormOfEduId equals f.Id
                             join e in context.Educations
                             on t.EducationId equals e.Id

                            
                select new TrainerDetailDto()
                {
                    TrainerId = t.TrainerId,
                    TrainerName = t.TrainerName,
                    TrainerSurname = t.TrainerSurname,
                    TrainerBranch = t.TrainerBranch,
                    AddressName = a.AddressName,

                    TrainerPhone = t.TrainerPhone,
                    TrainerEmail = t.TrainerEmail,
                    TrainerDate = t.TrainerDate,
                    TrainerGender = t.TrainerGender,
                    TrainerSchool = t.TrainerSchool,
                    TrainerAbout = t.TrainerAbout,

                    AboutLessInfo = t.AboutLessInfo,
                    TrainerWage = t.TrainerWage,
                    FormOfEduName = f.FormOfEduName,
                    EducationName = e.EduName
                };
                return result.ToList();
            }
        }
    }
}
