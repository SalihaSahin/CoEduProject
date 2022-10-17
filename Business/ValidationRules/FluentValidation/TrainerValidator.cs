using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class TrainerValidator : AbstractValidator<Trainer>
    {
        public TrainerValidator()
        {
            RuleFor(t=> t.AboutLessInfo).NotEmpty();
            RuleFor(t => t.TrainerAbout).NotEmpty();
            RuleFor(t => t.TrainerBranch).NotEmpty();
            RuleFor(t => t.TrainerDate).NotEmpty();
            RuleFor(t => t.TrainerEmail).NotEmpty();
            RuleFor(t => t.TrainerGender).NotEmpty();
            RuleFor(t => t.TrainerName).NotEmpty();
            RuleFor(t => t.TrainerPasswordHash).NotEmpty();
            RuleFor(t => t.TrainerPasswordSalt).NotEmpty();
            RuleFor(t => t.TrainerPhone).Length(11).WithMessage("Telefon numaranızı kontrol edin");
            RuleFor(t => t.TrainerSchool).NotEmpty();
            RuleFor(t => t.TrainerSurname).NotEmpty();
            RuleFor(t => t.TrainerWage).NotEmpty();
            

        }
    }
}
