using System.Web.Mvc;
using Foundation.TaxonomyInSitecore.Configuration;

namespace Foundation.TaxonomyInSitecore.Controllers
{
    public class TaxonomyController : Controller
    {
        public ActionResult Index()
        {
            var currentPage = Sitecore.Context.Item;
            Sitecore.Data.Items.Item myItem = (Sitecore.Data.Items.Item) currentPage;

            Sitecore.Data.Fields.MultilistField multiselectField = myItem.Fields[ConfigSettings.TaxonomyField];

            Sitecore.Data.Items.Item[] tags = multiselectField.GetItems();
            return View("~/Views/Taxonomy/Tags2.cshtml", tags);
        }
    }
}