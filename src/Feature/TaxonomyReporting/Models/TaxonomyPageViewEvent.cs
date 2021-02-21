using System;
using Sitecore.XConnect;

namespace TaxonomyReporting.Models
{
    public class TaxonomyPageViewEvent : Event
    {
        public TaxonomyPageViewEvent(Guid definitionId, DateTime timestamp) : base(definitionId, timestamp)
        {
        }
    }
}
