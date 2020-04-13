using System;
using System.Globalization;

namespace DeveloperQuiz.Utils
{
    public class DatetimeUtil
    {
        public bool IsOverlapped(string start1, string end1, string start2, string end2)
        {
            DateTime tStartA = parseStringToDate(start1);
            DateTime tEndA = parseStringToDate(end1);
            DateTime tStartB = parseStringToDate(start2);
            DateTime tEndB = parseStringToDate(end2);
            return tEndA > tStartB || tStartA > tEndB;
        }
        private DateTime parseStringToDate(string date)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(date, "yyyyMMdd", provider);
        }
    }
}
