using System;
using System.Collections.Generic;
using System.Text;

namespace NHCM.Application.Common.StringProcessor
{
    public class StringCleaner
    {
        public static string CleanValue(string val)
        {
            return !String.IsNullOrWhiteSpace(val) ? val.Trim() : "درج نگردیده";
        }
    }
   
}
