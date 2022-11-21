using Business.Abstract;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            this.creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCardCreateDto creditCardCreateDto)
        {
            var creditCardForCreate = new CreditCard()
            {
                UserId = creditCardCreateDto.UserId,
                ExpiryDate = creditCardCreateDto.ExpiryDate,
                CVV = creditCardCreateDto.CVV,
                CardNumber = creditCardCreateDto.CardNumber,
                FirstName=creditCardCreateDto.FirstName,
                LastName=creditCardCreateDto.LastName

            };

            creditCardDal.Add(creditCardForCreate);
            return new SuccessResult();
        }

        public IDataResult<CreditCard> GetByCreditCardId(int creditCardId)
        {
            return new SuccessDataResult<CreditCard>(creditCardDal.Get(c => c.Id == creditCardId));
        }

        public IDataResult<List<CreditCard>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<CreditCard>>(creditCardDal.GetAll(u => u.UserId == userId));
        }
    }
}
