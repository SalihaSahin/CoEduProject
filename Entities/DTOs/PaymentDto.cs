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
        public string UserFullName { get; set; }
        public string LessonName { get; set; }
    }
}
