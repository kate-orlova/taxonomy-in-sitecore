using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Analytics.Aggregation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
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

            var occurrences = new List<VisitGroupMeasurement<string>>();
            var events = context.Interaction.Events.Where(e => e.DefinitionId == TaxonomyPageViewEvent.EventDefinitionId && !string.IsNullOrEmpty(e.Data));
            /*var list = events.Select(e => new
            {
                Key = e.Data,
                ParentId = e.ParentEventId
            }).GroupBy(e => e.Key).ToList();

            list.Select(groupedTags =>
                new VisitGroupMeasurement<string>(new VisitGroup(groupedTags.Key, true), groupedTags.Select(s => s.Key)));*/

            foreach (var interactionEvent in events)
            {
                if (interactionEvent.DefinitionId == TaxonomyPageViewEvent.EventDefinitionId &&
                    !string.IsNullOrEmpty(interactionEvent.Data))
                {
                    var tagNames = interactionEvent.Data.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var tagName in tagNames)
                    {
                        occurrences.Add(new VisitGroupMeasurement<string>(new VisitGroup(tagName), new[] { tagName }));
                    }
                }
            }

            return occurrences;
        }
    }
}