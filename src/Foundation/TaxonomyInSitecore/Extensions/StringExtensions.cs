using System;
using System.Collections.Generic;
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

        public static List<Guid> ToGuidList(this string value, string separator = "|")
        {
            return value.SafeSplit(separator)
                .Select(x => x.NotEmpty() ? x.Trim() : string.Empty)
                .Where(x => Guid.TryParse(x, out _))
                .Select(Guid.Parse)
                .ToList();
        }
    }
}