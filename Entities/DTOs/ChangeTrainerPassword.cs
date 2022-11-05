using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ChangeTrainerPassword:IDto
    {
        public string TrainerEmail { get; set; }
        public string OldPassWord { get; set; }
        public string NewPassword { get; set; }
    }
}
