using System;

namespace Foundation.TaxonomyInSitecore.Configuration
{
    public static class ConfigSettings
    {
        public static string TaxonomyField => GetSetting(Constants.TaxonomyField);
        public static string GetSetting(string settingName, string defaultValue = null)
        {
            var settingValue = Sitecore.Configuration.Settings.GetSetting(settingName);

            if (string.IsNullOrEmpty(settingValue))
            {
                settingValue = defaultValue;
            }
            return settingValue;
        }

        public static Guid GetGuidSetting(string settingName)
        {
            var settingValue = Sitecore.Configuration.Settings.GetSetting(settingName);

            if (Guid.TryParse(settingValue, out var parsedValue))
            {
                return parsedValue;
            }
            return Guid.Empty;
        }
    }
}