using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHCM.Application.Infrastructure.Extensions
{
    public class ValidatorForSpecialCharsInStrings : PropertyValidator
    {
        // private readonly List<string> _ListOfCharacters;


        private readonly string _Character;

        //public ValidatorForSpecialCharsInStrings(List<string> ListofCharacters, string PropertyName) : base (ErrorMessageBuilder(ListofCharacters, PropertyName, null))
        //{

        //}
        public ValidatorForSpecialCharsInStrings(string Character, string PropertyName) : base (ErrorMessageBuilder(/*null,*/ PropertyName, Character))
        {
            _Character = Character;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {


            if (context.PropertyValue.ToString().Contains(_Character)) return false;
            else return true;

           
        }
















        private static string ErrorMessageBuilder(/*List<string> ListOfCharacters,*/ string PropertyName, string Character)
        {

            StringBuilder MessageBuilder = new StringBuilder();


            //// If Constructor(List<string> ListofCharacters, string PropertyName) is used
            //if (string.IsNullOrEmpty(Character))
            //{
            //    MessageBuilder.Append(PropertyName + " cannot include any of these letters");

            //    foreach (string character in ListOfCharacters)
            //        MessageBuilder.Append(character).Append(",");
            //}

            // If Constructor(string Character, string PropertyName) is used
            //else
            //{
                MessageBuilder.Append(PropertyName + " cannot include "+ Character);
            //}

            return MessageBuilder.ToString();
        }
    }
}
