using Foundation.TaxonomyInSitecore.Configuration;
using Sitecore.Analytics.Pipelines.ProcessItem;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using System.Linq;
using TaxonomyReporting.Models;

namespace TaxonomyReporting.Pipelines
{
    public class RegisterTaxonomyPageEvent : ProcessItemProcessor
    {
        public override void Process(ProcessItemArgs args)
        {
            Assert.ArgumentNotNull((object)args, nameof(args));
            Assert.ArgumentNotNull((object)args.Interaction, nameof(args.Interaction));
            Assert.IsNotNull((object)args.Interaction.CurrentPage, "The current page of the specified interaction is not initialized.");

            var tagNames = GetTagNames(Sitecore.Context.Item);

            var pageData = new Sitecore.Analytics.Data.PageEventData("Taxonomy Page View", TaxonomyPageViewEvent.EventDefinitionId)
            {
                Data = tagNames,
                Text = "Viewed page tagged with taxonomy",
                DataKey = "TagNames"
            };

            args.Interaction.CurrentPage.Register(pageData);
            
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
