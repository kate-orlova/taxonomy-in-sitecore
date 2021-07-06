using System;

namespace TaxonomyReporting.Configuration
{
    public static class ConfigSettings
    {
        public static Guid TaxonomyPageViewEventId  => Foundation.TaxonomyInSitecore.Configuration.ConfigSettings.GetGuidSetting("TaxonomyPageViewEventId");
    }
}