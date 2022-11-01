using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TrainerCreateDto : IDto
    {
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string TrainerSurname { get; set; }
        public string TrainerPhone { get; set; }
        public string TrainerPassword{ get; set; }
        public string TrainerEmail { get; set; }
        public DateTime TrainerDate { get; set; }
        public string TrainerGender { get; set; }
        public string TrainerBranch { get; set; }
        public string TrainerSchool { get; set; }
        public string TrainerAbout { get; set; }
        public string AboutLessInfo { get; set; }
        public int AddressId { get; set; }
        public int TrainerWage { get; set; }
        public int FormOfEduId { get; set; }
        public int EducationId { get; set; }

    }
}
