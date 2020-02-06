using System;

namespace Bitbucket.Cloud.Net.Common.Converters
{
    public static class DateTimeConverter
    {
        public static string ConvertToString(DateTime value)
        {
            return value.ToString("yyyy-MM-ddTHH:mm:ss.sssZ");
        }

        public static string ConvertToString(DateTime? value)
        {
            return value.HasValue
                ? ConvertToString(value.Value)
                : null;
        }
    }
}
