using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Extensions
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this string value, T defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return Enum.IsDefined(typeof(T), value) ?
                (T)Enum.Parse(typeof(T), value, true) :
                defaultValue;
        }
    }
}
