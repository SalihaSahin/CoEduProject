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
    public class EfPaymentDal: EfEntityRepositoryBase<Payment, CoEduContext>, IPaymentDal
    {
        public List<PaymentDto> GetPaymentDetailsByUserId(int userId)
        {
            using (CoEduContext context = new CoEduContext())
            {
                var result = from p in context.Payments
                             join t in context.Trainers
                             on p.TrainerId equals t.TrainerId
                             join c in context.CreditCards
                             on p.CreditCardId equals c.Id
                             where c.UserId == userId
                             select new PaymentDto()
                             {
                                 CreditCardNumber = c.CardNumber,
                                 Total = p.Total,
                                 PaymentDate = p.PaymentDate,
                                 TrainerFullName = t.TrainerName + " " + t.TrainerSurname,
                                 UserFullName= c.FirstName +" "+c.LastName,
                                 LessonName=t.TrainerBranch
                             };
                return result.ToList();
            }
        }

        
    }
}
