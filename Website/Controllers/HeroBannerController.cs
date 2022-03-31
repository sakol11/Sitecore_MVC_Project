using AltudoBatch1.Feature.DetailPage.Models;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltudoBatch1.Feature.DetailPage.Controllers
{
    public class HeroBannerController : Controller
    {
        // GET: HeroBanner
        public ActionResult Index()
        {
            var contextitem = Sitecore.Context.Item;
            HeroBanner heroBanner = new HeroBanner
            {
                HeroImage = new HtmlString(FieldRenderer.Render(contextitem, "HeroImage"))
            };

            return View("/Views/Altudo/DetailsPage/HeroBanner.cshtml", heroBanner);
        }
    }
}