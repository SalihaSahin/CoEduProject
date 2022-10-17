using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TrainerForRegisterDto:IDto
    {
        public string TrainerName { get; set; }
        public string TrainerSurName { get; set; }
        public string TrainerEmail { get; set; }
        public string TrainerPassword { get; set; }
    }
}
