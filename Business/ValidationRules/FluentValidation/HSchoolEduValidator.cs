using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class HSchoolEduValidator : AbstractValidator<HSchoolEdu>
    {
        public HSchoolEduValidator()
        {
            RuleFor(h => h.EduName).NotEmpty();
        }
    }
}
