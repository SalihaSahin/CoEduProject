using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserUpdateDto : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
        public string UserEmail { get; set; }
    }
}
