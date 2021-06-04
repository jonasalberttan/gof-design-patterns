using System;

namespace Gof.Design.Patterns.Winforms.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Format to yyyy-MM-dd
        /// </summary>
        /// <param name=""></param>
        public static String StandardFormat(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        public static String StandardDt(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd hh:mm tt");
        }
    }
}
