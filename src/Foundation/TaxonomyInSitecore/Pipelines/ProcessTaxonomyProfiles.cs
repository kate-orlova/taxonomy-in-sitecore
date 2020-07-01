using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Analytics.Pipelines.ProcessItem;
using Sitecore.Data.Fields;

namespace Foundation.TaxonomyInSitecore.Pipelines
{
    public class ProcessTaxonomyProfiles : ProcessItemProcessor
    {
        public override void Process(ProcessItemArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            var item = Context.Item;

            var taxonomyField = (MultilistField)item.Fields["Programming Language"];

            foreach (var tag in taxonomyField.GetItems())
            {
                //TODO: assign tag Profile Cards to the context item
            }
        }
    }
}