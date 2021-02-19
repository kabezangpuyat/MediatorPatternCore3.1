using System;
using System.Collections.Generic;
using System.Text;

namespace MNV.Domain.Extensions
{
    public static class DateExtensions
    {
        public static DateTime? ToDate(this string date)
        {
            if (DateTime.TryParse(date, out DateTime dateTime))
            {
                return dateTime;
            }
            else
            {
                return (DateTime?)null;
            }
        }
    }
}
