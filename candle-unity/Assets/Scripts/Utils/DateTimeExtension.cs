using System;

namespace Utils
{
    public static class DateTimeExtension
    {
        public static readonly DateTime StartTime = new DateTime(1970, 1, 1, 0, 0, 0);

        public static long DateTimeToDays(this DateTime dateTime)
        {
            return (long)(dateTime - StartTime).TotalDays;
        }

        public static bool IsSameDay(this DateTime curTime, DateTime dateTime)
        {
            if (curTime.Year != dateTime.Year)
            {
                return false;
            }

            if (curTime.Month != dateTime.Month)
            {
                return false;
            }

            if (curTime.Day != dateTime.Day)
            {
                return false;
            }

            return true;
        }
    }
}