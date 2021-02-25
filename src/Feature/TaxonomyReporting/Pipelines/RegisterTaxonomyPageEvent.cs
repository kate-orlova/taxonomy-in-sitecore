using Foundation.TaxonomyInSitecore.Configuration;
using Sitecore.Analytics.Pipelines.ProcessItem;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using System.Linq;

namespace TaxonomyReporting.Pipelines
{
    public class RegisterTaxonomyPageEvent : ProcessItemProcessor
    {
        public override void Process(ProcessItemArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));

            var tagNames = GetTagNames(Sitecore.Context.Item);            
        }

        protected string GetTagNames(Item item)
        {
            if (item != null)
            {
                var taxonomyField = (MultilistField)item.Fields[ConfigSettings.TaxonomyField];

                if (taxonomyField != null)
                {
                    var taxonomyItems = taxonomyField.GetItems();
                    var tags = string.Join("|", taxonomyItems.Select(x => x.Name));
                    return tags;
                }
            }
            return string.Empty;
        }
    }
}
