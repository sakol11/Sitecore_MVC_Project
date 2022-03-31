using AltudoBatch1.Feature.DetailPage.Models;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltudoBatch1.Feature.DetailPage.Controllers
{
    public class DetailedBlogController : Controller
    {
        // GET: DetailedBlog
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            DetailedBlog detailBlogg = new DetailedBlog()
            {
                DetailBlog = new HtmlString(FieldRenderer.Render(contextItem, "DetailedBlog"))
            };
            return View("/Views/Altudo/DetailsPage/DetailBlog.cshtml",detailBlogg);
        }
    }
}