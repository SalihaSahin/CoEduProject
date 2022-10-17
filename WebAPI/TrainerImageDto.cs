using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TrainerImageDto:IDto
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public string ImagePath { get; set; }
    }
}
