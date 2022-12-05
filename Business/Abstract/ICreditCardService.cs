using Core.Utitlities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<int> Add(CreditCardCreateDto creditCardCreateDto);
        IResult Update(CreditCardUpdateDto creditCardUpdateDto);
        IDataResult<CreditCard> GetByCreditCardId(int creditCardId);
        IDataResult<CreditCard> GetByCreditCardNumber(string cardNumber);
        IDataResult<List<CreditCard>> GetByUserId(int userId);
    }
}
