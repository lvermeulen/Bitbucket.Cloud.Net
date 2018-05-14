namespace Bitbucket.Cloud.Net.Common.Converters
{
    public class BoolConverter
    {
        public static string ConvertToString(bool value) => value
            ? "true"
            : "false";

        public static string ConvertToString(bool? value) => value.HasValue
            ? ConvertToString(value.Value)
            : null;

        //public static bool ConvertFromString(string value) => value.Equals("true", StringComparison.OrdinalIgnoreCase);
    }
}
