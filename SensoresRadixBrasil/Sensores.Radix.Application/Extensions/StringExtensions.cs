using System;
using System.Collections.Generic;
using System.Text;

namespace Sensores.Radix.Application.Extensions
{
    public static partial class StringExtension
    {
        public static bool IsNumeric(this string value)
        {
            long retNum;
            return long.TryParse(value, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        }
    }
}
