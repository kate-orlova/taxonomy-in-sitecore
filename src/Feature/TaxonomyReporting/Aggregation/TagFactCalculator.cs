using Sitecore.Analytics.Aggregation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.FactCalculation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
using TaxonomyReporting.Models;

namespace TaxonomyReporting.Aggregation
{
    class TagFactCalculator : IFactCalculator<TaxonomyMetrics, string>
    {
        public TaxonomyMetrics CalculateFactsForGroup(VisitGroupMeasurement<string> groupMeasurement, IInteractionAggregationContext context)
        {

            return new TaxonomyMetrics
            {

                EngagementValue = 1,
                Visits = 1
            };
        }
    }
}
