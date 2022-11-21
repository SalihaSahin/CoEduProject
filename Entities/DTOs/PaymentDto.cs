using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentDto: IDto
    {
        public string CreditCardNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TrainerFullName { get; set; }
    }
}
