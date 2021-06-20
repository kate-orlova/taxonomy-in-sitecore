using System;
using System.Collections.Generic;
using Sitecore.XConnect;

namespace TaxonomyReporting.Models
{
    public class TaxonomyPageViewEvent : Event
    {
        public TaxonomyPageViewEvent(List<string> taxonomyTags, DateTime timestamp) : base(TaxonomyPageViewEvent.EventDefinitionId, timestamp)
        {
            TaxonomyTags = taxonomyTags;
        }

        public static readonly Guid EventDefinitionId = new Guid("B665209F-6AE3-413B-97CC-2E9A9B3DD276");

        public List<string> TaxonomyTags { get; set; }
    }
}
