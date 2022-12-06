using Business.Abstract;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal paymentDal;
        private readonly ICreditCardService creditCardService;
        private readonly ITrainerService trainerService;

        public PaymentManager(IPaymentDal paymentDal, ICreditCardService creditCardService, ITrainerService trainerService)
        {
            this.paymentDal = paymentDal;
            this.creditCardService = creditCardService;
            this.trainerService = trainerService;
        }

        public IResult Add(PaymentCreateDto paymentCreateDto)
        {
            var creditCard = creditCardService.GetByCreditCardId(paymentCreateDto.CreditCardId);
            var trainer = trainerService.GetById(paymentCreateDto.TrainerId);
            var paymentForCreate = new Payment()
            {
                CreditCardId = paymentCreateDto.CreditCardId,
                TrainerId = paymentCreateDto.TrainerId,
                Total = paymentCreateDto.Hour * trainer.Data.TrainerWage,
                PaymentDate = DateTime.Now
            };
            paymentDal.Add(paymentForCreate);
            return new SuccessResult();
        }

        public IDataResult<List<PaymentDto>> GetAllByUserId(int id)
        {
            var creditCards = creditCardService.GetByUserId(id);
            var payments = 
                creditCards.Data.SelectMany(c=>paymentDal.GetAll(p=>p.CreditCardId==c.Id ).Select(d=>new PaymentDto() { 
                 
                CreditCardNumber=c.CardNumber,
                PaymentDate= d.PaymentDate,
                Total= d.Total,
                TrainerFullName=c.FirstName+" "+ c.LastName
            }));

            return new SuccessDataResult<List<PaymentDto>>(payments.ToList());
        }

    
    }
}
