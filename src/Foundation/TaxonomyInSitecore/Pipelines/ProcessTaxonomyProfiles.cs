using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Analytics.Pipelines.ProcessItem;
using Sitecore.Data.Fields;
using Sitecore.Analytics.Data;
using Sitecore.Data.Items;
using Foundation.TaxonomyInSitecore.Configuration;

namespace Foundation.TaxonomyInSitecore.Pipelines
{
    public class ProcessTaxonomyProfiles : ProcessItemProcessor
    {
        public override void Process(ProcessItemArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            var item = Context.Item;

            var taxonomyField = (MultilistField)item.Fields[ConfigSettings.TaxonomyField];

            foreach (var tag in taxonomyField.GetItems())
            {
                // assign tag Profiles to the context item
                TrackingField tagTrackingField = GetTagProfile(tag);
                if (tagTrackingField != null)
                    args.TrackingParameters.Add(tagTrackingField);
            }
        }
        private TrackingField GetTagProfile(Item tag)
        {
            if (!string.IsNullOrEmpty(tag["__Tracking"]))
            {
                Field field = tag.Fields["__Tracking"];
                if (field != null)
                    return new TrackingField(field);
            }

            return null;
        }
    }
}