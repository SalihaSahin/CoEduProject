using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanıcı ismini doldurun");
            RuleFor(u => u.UserSurname).NotEmpty().WithMessage("Kullanıcı soyismini doldurun");
            RuleFor(u => u.UserEmail).NotEmpty().WithMessage("Email boş bırakılamaz");
        }
    }
}
