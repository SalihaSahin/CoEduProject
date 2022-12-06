using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator: AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CardNumber).NotEmpty().WithMessage("Kart Numarası boş bırkılamaz");
            RuleFor(c => c.CVV).NotEmpty().WithMessage("CVV boş bırkılamaz");
            RuleFor(c => c.ExpiryDate).NotEmpty().WithMessage("Son Kullanma Tarihi Boş Bırakılamaz");
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("İsim alanı Boş Bırakılamaz");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Soyisim alanı Boş Bırakılamaz");
            
        }
    }
}
