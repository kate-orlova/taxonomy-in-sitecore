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

        public static readonly Guid EventDefinitionId = new Guid("FCFA9424-0558-4892-AB30-BB70B9F51866");

        public List<string> TaxonomyTags { get; set; }
    }
}
