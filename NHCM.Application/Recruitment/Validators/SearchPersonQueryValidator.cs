using FluentValidation;
using NHCM.Application.Recruitment.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Application.Recruitment.Validators
{
    public class SearchPersonQueryValidator : AbstractValidator<SearchPersonQuery>
    {
        public SearchPersonQueryValidator()
        {
            RuleFor(x => x.FirstName).MaximumLength(60).WithMessage("تعداد حروف وارد شده نباید از 60 حرف بیشتر باشد");
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("تعداد حروف حد اقل باید یک حرف باشد");
            
            RuleFor(x => x.LastName).MaximumLength(60).WithMessage("تعداد حروف وارد شده نباید از 60 حرف بیشتر باشد");
            RuleFor(x => x.FatherName).MaximumLength(60).WithMessage("تعداد حروف وارد شده نباید از 60 حرف بیشتر باشد"); ;
            RuleFor(x => x.GrandFatherName).MaximumLength(6).WithMessage("تعداد حروف وارد شده نباید از 60 حرف بیشتر باشد"); ;
        }

        // If at least one search term is defined.
        public static bool IsAtLeastOneSearchTerm(SearchPersonQuery model)
        {
            if (!string.IsNullOrEmpty(model.FirstName) || !string.IsNullOrEmpty(model.LastName) || !string.IsNullOrEmpty(model.FatherName) || !string.IsNullOrEmpty(model.GrandFatherName))
                return true;
            else
                return false;
        }
    }
}
