using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FormOfEdu:IEntity
    {
        public int Id { get; set; }
        public string FormOfEduName { get; set; }
    }
}
