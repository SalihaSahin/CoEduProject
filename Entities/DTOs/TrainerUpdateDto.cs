using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TrainerUpdateDto: IDto
    {
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string TrainerSurname { get; set; }
        public string TrainerBranch { get; set; }
        public string AddressName { get; set; }
        public int TrainerWage { get; set; }
        public string FormOfEduName { get; set; }
        public string EducationName { get; set; }
        public string TrainerPhone { get; set; }
        public string TrainerEmail { get; set; }
        public DateTime TrainerDate { get; set; }
        public string TrainerGender { get; set; }
        public string TrainerSchool { get; set; }
        public string TrainerAbout { get; set; }
        public string AboutLessInfo { get; set; }
    }
}
