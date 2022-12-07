using Core.Utitlities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface  IPaymentService
    {
        IResult Add(PaymentCreateDto paymentCreateDto);
        IDataResult<List<PaymentDto>> GetAllByUserId(int id);
        IDataResult<List<PaymentDto>> GetPaymentDetailsByUserId(int userId);
    }
}
