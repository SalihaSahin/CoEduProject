using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class SportEduValidator : AbstractValidator<SportEdu>
    {
        public SportEduValidator()
        {
            RuleFor(s => s.SportName).NotEmpty();
        }
    }
}
