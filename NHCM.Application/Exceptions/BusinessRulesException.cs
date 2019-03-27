using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Application.Exceptions
{
    public class BusinessRulesException : Exception
    {
        public BusinessRulesException(string Message) : base (Message)
        {

        }
    }
}
