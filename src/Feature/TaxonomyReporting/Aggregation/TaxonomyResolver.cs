﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Analytics.Aggregation;
using Sitecore.ExperienceAnalytics.Aggregation.FlexibleMetrics.Framework.Grouping;
using TaxonomyReporting.Configuration;
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
            var events = context.Interaction.Events.Where(e => e.DefinitionId == ConfigSettings.TaxonomyPageViewEventId && !string.IsNullOrEmpty(e.Data));

            foreach (var interactionEvent in events)
            {
                if (interactionEvent.DefinitionId == ConfigSettings.TaxonomyPageViewEventId &&
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