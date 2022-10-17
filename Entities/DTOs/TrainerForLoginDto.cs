using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TrainerForLoginDto:IDto
    {
        public string TrainerEmail { get; set; }
        public string TrainerPassword { get; set; }
    }
}
