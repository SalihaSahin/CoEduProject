using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CategoryDetailDto: IDto
    {
        public int Id { get; set; }
        public int AddressName { get; set; }
        public int EduName { get; set; }
        public int FromOfEduName { get; set; }
    }
}
