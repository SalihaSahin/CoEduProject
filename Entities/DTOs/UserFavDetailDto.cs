using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserFavDetailDto:IDto
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int UserId { get; set; }
        public string TrainerBranch { get; set; }
        public string TrainerEducationName { get; set; }
        public string TrainerFullName { get; set; }
    }
}
