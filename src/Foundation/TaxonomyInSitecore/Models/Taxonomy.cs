using System.Collections.Generic;

namespace Foundation.TaxonomyInSitecore.Models
{
    public class Taxonomy
    {
        public virtual IEnumerable<DictionaryEntry> ContentTags  {get; set;}
    }
}