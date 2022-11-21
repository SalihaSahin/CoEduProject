using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentCreateDto: IDto
    {
        public int  CreditCardId { get; set; }
        public uint  Hour { get; set; }
        public int TrainerId { get; set; }

    }
}
