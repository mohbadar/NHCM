using System;
using System.Collections.Generic;
using System.Text;
using NHCM.Application.Infrastructure.Extensions;
using FluentValidation;
using NHCM.Application.Recruitment.Commands;

namespace NHCM.Application.Recruitment.Validators
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            
            RuleFor(p => p.FirstName).NotNull().NotEmpty().MinimumLength(3).WithMessage("نام باید حد اقل دارای سه حرف باشد");
            RuleFor(p => p.FirstName).CannotInclude("$", "نام");
            RuleFor(p => p.FirstName).CannotInclude(".", "نام");

            RuleFor(p => p.FirstName).MaximumLength(50).WithMessage("نام میتواند حد اکثر دارای پنجاه حرف باشد");
            RuleFor(p => p.LastName).NotNull().NotEmpty().MinimumLength(3).WithMessage("تخلص فرد باید حداقل دارای  سه حرف باشد");
           
            

        }

    }
}
