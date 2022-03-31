using AltudoBatch1.Feature.DetailPage.Models;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltudoBatch1.Feature.DetailPage.Controllers
{
    public class DetailPagesController : Controller
    {
        // GET: DetailPage
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;

            DetailPages detailPage = new DetailPages()
            {
                Title = new HtmlString(FieldRenderer.Render(contextItem, "Title")),
                Description = new HtmlString(FieldRenderer.Render(contextItem, "Description")),
                CardImage = new HtmlString(FieldRenderer.Render(contextItem, "CardImage")),
                HeroImage = new HtmlString(FieldRenderer.Render(contextItem, "HeroImage"))
            };
            return View("/Views/Altudo/DetailsPage/DetailsPage.cshtml",detailPage);
        }
    }
}