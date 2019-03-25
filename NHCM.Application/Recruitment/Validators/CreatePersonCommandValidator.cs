using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using NHCM.Application.Recruitment.Commands;

namespace NHCM.Application.Recruitment.Validators
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            
            RuleFor(p => p.FirstName).NotEmpty().MinimumLength(2).WithMessage("نام باید حد اقل دارای یک حرف باشد");
            RuleFor(p => p.FirstName).MaximumLength(5).WithMessage("نام باید حد اکثر دارای 5 حرف باشد");
           
        }

    }
}
