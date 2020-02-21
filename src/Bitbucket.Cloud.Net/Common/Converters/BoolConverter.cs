namespace Bitbucket.Cloud.Net.Common.Converters
{
    public static class BoolConverter
    {
        public static string ConvertToString(bool value) => value
            ? "true"
            : "false";

        public static string ConvertToString(bool? value) => value.HasValue
            ? ConvertToString(value.Value)
            : null;
    }
}
