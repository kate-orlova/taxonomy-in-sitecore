using Sitecore.Analytics.Aggregation;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.ExperienceAnalytics.Aggregation.Calculator;
using Sitecore.ExperienceAnalytics.Aggregation.Data.Model;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.FactCalculation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
using TaxonomyReporting.Models;

namespace TaxonomyReporting.Aggregation
{
    class TagFactCalculator : IFactCalculator<TaxonomyMetrics, string>
    {
        private readonly ICalculator<CalculatedInteraction> _calculator;

        public TagFactCalculator()
        {
            _calculator = (ICalculator<CalculatedInteraction>)ServiceLocator.ServiceProvider.GetService(typeof(ICalculator<CalculatedInteraction>));
        }

        public TaxonomyMetrics CalculateFactsForGroup(VisitGroupMeasurement<string> groupMeasurement, IInteractionAggregationContext context)
        {
            var calculatedInteraction = CalculateInteraction(context);

            return new TaxonomyMetrics
            {
                EngagementValue = calculatedInteraction.EngagementValue,
                Visits = 1
            };
        }

        protected virtual CalculatedInteraction CalculateInteraction(IInteractionAggregationContext context)
        {
            Assert.ArgumentNotNull(context, nameof(context));
            var calculatedInteraction = _calculator.Calculate(context.Interaction);
            return calculatedInteraction;
        }
    }
}
