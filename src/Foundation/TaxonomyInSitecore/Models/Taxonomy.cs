using Foundation.TaxonomyInSitecore.Configuration;

namespace Foundation.TaxonomyInSitecore.Models
{
    public class Taxonomy
    {
        private Sitecore.Data.Items.Item _contextItem;
        private Sitecore.Data.Items.Item[] _tags;
        public virtual Sitecore.Data.Items.Item ContextItem
        {
            get
            {
                if (_contextItem != null)
                {
                    return _contextItem;
                }
                else
                {
                    _contextItem = Sitecore.Context.Item;
                    return _contextItem;
                }
            }
        }
        public virtual Sitecore.Data.Items.Item[] Tags
        {
            get
            {
                if (_tags != null)
                {
                    return _tags;
                }
                else
                {

                    Sitecore.Data.Fields.MultilistField multiselectField = this.ContextItem.Fields[ConfigSettings.TaxonomyField];

                    _tags = multiselectField.GetItems();
                    return _tags;
                }
            }
        }
    }
}