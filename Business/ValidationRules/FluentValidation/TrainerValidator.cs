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

            RuleFor(u => u.TrainerName).NotEmpty().WithMessage("Kullanıcı ismini doldurun");
            RuleFor(u => u.TrainerSurname).NotEmpty().WithMessage("Kullanıcı soyismini doldurun");
            RuleFor(u => u.TrainerEmail).NotEmpty().WithMessage("Email boş bırakılamaz");

        }
    }
}
