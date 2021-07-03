using Sitecore.Analytics.Aggregation.Data.Model;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Metrics;
using System;

namespace TaxonomyReporting.Models
{
    class TaxonomyMetrics : DictionaryValue, IMergeableMetric<TaxonomyMetrics>
    {
        public int Visits { get; set; }
        public int EngagementValue { get; set; }

        public T MergeWith<T>(T other) where T : TaxonomyMetrics, new()
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return new T
            {
                Visits = Visits + other.Visits,
                EngagementValue = EngagementValue + other.EngagementValue
            };
        }
    }
}
