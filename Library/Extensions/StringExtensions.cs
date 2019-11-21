namespace MWork.Extensions.Microsoft.DependencyInjection.Extensions
{
    public static class StringExtensions
    {
        public static bool IsPresent(this string str)
        {
            return str.IsMissing() == false;
        }

        public static bool IsMissing(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static string NameNormalize(this string str)
        {
            return str.ToLowerInvariant();
        }
    }
}