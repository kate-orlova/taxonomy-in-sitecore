using Sitecore.Mvc.Controllers;
using System.Web.Mvc;
using Foundation.TaxonomyInSitecore.Models;

namespace Foundation.TaxonomyInSitecore.Controllers
{
    public class TaxonomyController : SitecoreController
    {
        public override ActionResult Index()
        {
            var Model = new ContentPage();
            return View("~/Views/Taxonomy/TagList.cshtml", Model);
        }
    }
}