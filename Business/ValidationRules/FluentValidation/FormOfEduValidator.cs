using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class FormOfEduValidator : AbstractValidator<FormOfEdu>
    {
        public FormOfEduValidator()
        {
            RuleFor(f => f.FormOfEduName).NotEmpty();
        }
    }
}
