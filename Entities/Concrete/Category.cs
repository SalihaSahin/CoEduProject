using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public int AddressId { get; set; }
        public int EduId { get; set; }
        public int FormOfEduId { get; set; }
    }
}
