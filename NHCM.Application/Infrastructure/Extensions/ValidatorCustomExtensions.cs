using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Application.Infrastructure.Extensions
{
    public static class ValidatorCustomExtensions
    {
        public static IRuleBuilderOptions<T, string> CannotInclude<T>(this IRuleBuilderInitial<T, string> ruleBuilder, string character, string propertyName)
        {
            return ruleBuilder.SetValidator(new ValidatorForSpecialCharsInStrings(character, propertyName));
        }

        //public static IRuleBuilder<T, string> CannotIncludeDigit<T> (this IRuleBuilder<T, string> ruleBuilder, string character, string propertyName)
        //{
        //    return throw NotImplementedException();
        //}
    }
}
