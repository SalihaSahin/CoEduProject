﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CreditCardCreateDto:IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public int UserId { get; set; }
        public int CVV { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
