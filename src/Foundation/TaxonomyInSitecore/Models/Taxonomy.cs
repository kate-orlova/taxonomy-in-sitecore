using System;
using System.Collections.Generic;

namespace Foundation.TaxonomyInSitecore.Models
{
    public class Taxonomy
    {
        public virtual IEnumerable<DictionaryEntry> ContentTags  {get; set;}
        public virtual List<Guid> ContentTagIds { get; set; }
    }
}