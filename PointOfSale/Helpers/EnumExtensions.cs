using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Helpers
{
    public static class EnumExtensions
    {
        public static int GetValue<TEnum>(string text)
        {
            return (int)Enum.Parse(typeof(TEnum), text);
        }
    }
}
