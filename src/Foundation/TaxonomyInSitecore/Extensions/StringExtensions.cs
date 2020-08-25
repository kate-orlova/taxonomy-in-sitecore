using System;
using System.Linq;

namespace Foundation.TaxonomyInSitecore.Extensions
{
    public static class StringExtensions
    {
        public static bool NotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
        }

        public static string[] SafeSplit(this string value, string separator)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Enumerable.Empty<string>().ToArray();
            }

            return value.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}