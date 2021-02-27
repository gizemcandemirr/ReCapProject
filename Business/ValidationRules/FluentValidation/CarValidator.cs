using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(10);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.BrandId == 1);
            RuleFor(c => c.ModelYear).Must(BigModel).WithMessage("Araba Model Yılı 1997'den büyük olmalıdır ");
        }

        private bool BigModel(int arg)
        {
            return arg >= 1997;
        }
    }
}
