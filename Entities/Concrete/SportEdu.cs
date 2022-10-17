using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SportEdu:IEntity
    {
        public int Id { get; set; }
        public string SportName { get; set; }
    }
}
