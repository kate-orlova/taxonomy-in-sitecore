using Sitecore.Analytics.Pipelines.ProcessItem;
using Sitecore.Diagnostics;

namespace TaxonomyReporting.Pipelines
{
    public class RegisterTaxonomyPageEvent : ProcessItemProcessor
    {
        public override void Process(ProcessItemArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));
        }
    }
}
