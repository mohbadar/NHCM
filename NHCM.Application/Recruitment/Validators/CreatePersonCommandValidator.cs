using System;
using System.Collections.Generic;
using System.Text;
using NHCM.Application.Infrastructure.Validations;
using FluentValidation;
using NHCM.Application.Recruitment.Commands;


namespace NHCM.Application.Recruitment.Validators
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {

            // FirstName
            
            RuleFor(p => p.FirstName).NotNull().NotEmpty().MinimumLength(3).WithMessage("نام کارمند باید حد اقل دارای سه حرف باشد" );
            RuleFor(p => p.FirstName).MaximumLength(50).WithMessage("نام کارمند میتواند حد اکثر دارای پنجاه حرف باشد" );
            RuleFor(p => p.FirstName)
                .CannotInclude(ValidationHelper.ForbiddenSymbols)
                .WithMessage(" نام کارمند نمی تواند یکی از حروف ذیل را داشته باشد " + ValidationHelper.StringyfyList(ValidationHelper.ForbiddenSymbols) );
            RuleFor(p => p.FirstName)
                .NoDigit()
                .WithMessage("نام کارمند نمیتواند دارای ارقام باشد" );
            RuleFor(p => p.FirstName)
                .DariTextOnly()
                .WithMessage("نام دری کارمند تنها به دری بوده میتواند" );



            // LastName

            RuleFor(p => p.LastName).NotNull().NotEmpty().MinimumLength(3).WithMessage("تخلص کارمند باید حد اقل دارای سه حرف باشد" );
            RuleFor(p => p.LastName)
                .MaximumLength(50)
                .WithMessage("تخلص کارمند میتواند حد اکثر دارای پنجاه حرف باشد" );
            RuleFor(p => p.LastName)
                .CannotInclude(ValidationHelper.ForbiddenSymbols)
                .WithMessage(" تخلص کارمند نمی تواند یکی از حروف ذیل را داشته باشد " + ValidationHelper.StringyfyList(ValidationHelper.ForbiddenSymbols) );
            RuleFor(p => p.LastName).NoDigit()
                .WithMessage("تخلص کارمند نمیتواند دارای ارقام باشد" );
            RuleFor(p => p.LastName).DariTextOnly()
                .WithMessage("تخلص دری کارمند تنها به دری بوده میتواند" );


            // FatherName

            RuleFor(p => p.FatherName)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .WithMessage("ولد کارمند حداقل دارای سه و حد اکثر دارای پنجاه حرف بوده میتواند");

            RuleFor(p => p.FatherName).CannotInclude(ValidationHelper.ForbiddenSymbols).WithMessage("");
            RuleFor(p => p.FatherName).DariTextOnly().WithMessage("ولد دری کارمند تنها به دری بوده میتواند");
            RuleFor(p => p.FatherName).NoDigit().WithMessage(" ولد دری کارمند نمی تواند دارای ارقام باشد");





        }

    }

  
}
