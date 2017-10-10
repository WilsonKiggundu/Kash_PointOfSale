using System;

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
