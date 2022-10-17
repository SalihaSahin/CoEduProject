using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class TrainerImage:IEntity
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public string ImagePath { get; set; }
       
    }
}
