using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBatch1.Feature.DetailPage.Models;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace AltudoBatch1.Feature.ListingPage.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            var cardsList = contextItem.GetChildren()
                .Select(x => new DetailPages
                {
                    Title = new HtmlString(FieldRenderer.Render(x, "Title")),
                    Description = new HtmlString(FieldRenderer.Render(x, "Description")),
                    CardImage = new HtmlString(FieldRenderer.Render(x, "CardImage")),
                    CardUrl = LinkManager.GetItemUrl(x)
                }).ToList();

            return View("/Views/Altudo/Listing.cshtml", cardsList);
        }
    }
}