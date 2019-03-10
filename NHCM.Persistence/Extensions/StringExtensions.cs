using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Persistence.Extensions
{
    public static class StringExtensions
    {
        public static string Right(this string sValue, int noOfExtraction)
        {


            return sValue.Substring(sValue.Length - noOfExtraction);

        }
    }
}
