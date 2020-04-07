using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp
{
    public static class DateTimeExtension
    {
        public static TimeSpan FromMsToTime(this int milliseconds)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(milliseconds).TimeOfDay;
        }
    }
}
