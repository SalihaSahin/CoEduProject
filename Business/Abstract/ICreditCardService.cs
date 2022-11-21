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
        IResult Add(CreditCardCreateDto creditCardCreateDto);
        IDataResult<CreditCard> GetByCreditCardId(int creditCardId);
        IDataResult<List<CreditCard>> GetByUserId(int userId);
    }
}
