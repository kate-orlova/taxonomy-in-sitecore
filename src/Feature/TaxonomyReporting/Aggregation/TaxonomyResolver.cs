using System;
using System.Collections.Generic;
using Sitecore.Analytics.Aggregation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
using Sitecore.XConnect.Collection.Model;
using TaxonomyReporting.Models;

namespace TaxonomyReporting.Aggregation
{
    public class TaxonomyResolver : IGroupResolver<string>
    {
        public IEnumerable<VisitGroupMeasurement<string>> MeasureGroupOccurrences(IInteractionAggregationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var browserData = context.Interaction.WebVisit()?.Browser;
            var events = context.Interaction.Events;
            var occurrences = new List<VisitGroupMeasurement<string>>();

            if (events != null)
            {
                foreach (var interactionEvent in events)
                {
                    if (interactionEvent.DefinitionId == TaxonomyPageViewEvent.EventDefinitionId &&
                        !string.IsNullOrEmpty(interactionEvent.Data))
                    {
                        var tagNames = interactionEvent.Data.Split(new []{"|"}, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var tagName in tagNames)
                        {
                            occurrences.Add(new VisitGroupMeasurement<string>(new VisitGroup(tagName), new []{ tagName }));
                        }
                    }
                }
            }

            return occurrences;
        }
    }
}