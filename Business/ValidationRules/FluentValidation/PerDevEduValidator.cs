using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PerDevEduValidator : AbstractValidator<PerDevEdu>
    {
        public PerDevEduValidator()
        {
            RuleFor(p => p.PerDevName).NotEmpty();
        }
    }
}
