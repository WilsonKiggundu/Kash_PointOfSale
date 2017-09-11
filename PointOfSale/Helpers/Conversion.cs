using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PointOfSale.Helpers
{
    public static class Conversion
    {
        public static TEnum GetEnumValue<TEnum>(this object obj)
        {
            return (TEnum) obj;
        }
        public static decimal? ToDecimal(this string str)
        {
            return string.IsNullOrEmpty(str) ? (decimal?) null : Convert.ToDecimal(str);
        }
        public static decimal? ToDecimal(this object obj)
        {
            return obj == null ? (decimal?) null : Convert.ToDecimal(obj);
        }

        public static int? ToInteger(this object obj)    
        {
            return obj == null ? (int?) null : Convert.ToInt32(obj);
        }

        public static int? ToInteger(this string str)    
        {
            return string.IsNullOrEmpty(str) ? (int?)null : Convert.ToInt32(str);
        }

        public static string SplitCamelCase(this string str)
        {
            return Regex.Replace(str, "(\\B[A-Z])", " $1");
        }
    }
}
