using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class TrainerImageValidator : AbstractValidator<TrainerImage>
    {
        public TrainerImageValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.Id).NotNull();
        }
    }
}
