using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserFav:IEntity
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int UserId { get; set; }
        public int EducationId { get; set; }
        public string TrainerBranch { get; set; }
        public string TrainerEducationName { get; set; }
        public string TrainerFullName { get; set; }
    }
}
