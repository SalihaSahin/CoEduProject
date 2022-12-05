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

        public IDataResult<int> Add(CreditCardCreateDto creditCardCreateDto)
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
            return new SuccessDataResult<int>(creditCardForCreate.Id);
        }

        public IResult Update(CreditCardUpdateDto creditCardUpdateDto)
        {
            var creditCardForUpdate = creditCardDal
                .Get(creditCard => creditCard.CardNumber == creditCardUpdateDto.CardNumber);

            creditCardForUpdate.UserId = creditCardUpdateDto.UserId;
            creditCardForUpdate.FirstName = creditCardUpdateDto.FirstName;
            creditCardForUpdate.LastName = creditCardUpdateDto.LastName;
            creditCardForUpdate.CardNumber = creditCardUpdateDto.CardNumber;
            creditCardForUpdate.CVV = creditCardUpdateDto.CVV;
            creditCardForUpdate.ExpiryDate = creditCardUpdateDto.ExpiryDate;

            creditCardDal.Update(creditCardForUpdate);

            return new SuccessResult();
        }

        public IDataResult<CreditCard> GetByCreditCardId(int creditCardId)
        {
            return new SuccessDataResult<CreditCard>(creditCardDal.Get(c => c.Id == creditCardId));
        }

        public IDataResult<CreditCard> GetByCreditCardNumber(string cardNumber)
        {
            return new SuccessDataResult<CreditCard>(creditCardDal.Get(c => c.CardNumber == cardNumber));
        }

        public IDataResult<List<CreditCard>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<CreditCard>>(creditCardDal.GetAll(u => u.UserId == userId));
        }


    }
}
