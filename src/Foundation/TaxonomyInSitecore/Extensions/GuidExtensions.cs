using System;

namespace Foundation.TaxonomyInSitecore.Extensions
{
    public static class GuidExtensions
    {
        public static string ToDigitString(this Guid value)
        {
            return value.ToString("N");
        }
    }
}