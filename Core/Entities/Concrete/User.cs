using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class User:IEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }
       // public DateTime UserDate { get; set; }
        //public string UserPhone { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public string UserEmail { get; set; }
        public byte[] UserPasswordSalt { get; set; }
        public bool Status { get; set; }
    }
}
