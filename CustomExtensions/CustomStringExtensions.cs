using System;
using System.Collections.Generic;
using System.Text;

namespace LearningLinq.CustomExtensions
{
    // Extensions holder
    public static class CustomExtensions
    {
        public static string ChangeFirstLetterCase(this string inputString)
        {
            if (inputString.Length == 0) return inputString;

            char[] charArray = inputString.ToCharArray();
            charArray[0] = char.IsUpper(charArray[0]) ? char.ToLower(charArray[0]) : char.ToUpper(charArray[0]);
            return new string(charArray);

        }
    }

}
