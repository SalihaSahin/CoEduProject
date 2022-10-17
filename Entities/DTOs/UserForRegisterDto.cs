using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

    }
}
