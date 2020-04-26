using System;

namespace HSESupporter.Services
{
    public static class Extensions
    {
        public static string GetDateTimeText(this string str)
        {
            var dateTime = DateTime.Parse(str);

            return dateTime.ToString("HH:mm");
        }
    }
}