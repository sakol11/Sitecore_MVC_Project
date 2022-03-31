using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBatch1.Feature.DetailPage.Models;

namespace AltudoBatch1.Feature.DetailPage.Controllers
{
    public class FeaturedCommentsController : Controller
    {
        // GET: FeaturedComments
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            var ReviewComments = contextItem.GetChildren()
                .Where(x => x.TemplateName == "ReviewComment")
                .Select(x => new ReviewComments
                {
                    Name = x.Fields["Name"].Value,
                    EmailId = x.Fields["EmailId"].Value,
                    Comment = x.Fields["Comment"].Value,
                    Rating = Convert.ToInt32(x.Fields["Rating"].Value),
                    PostedDate = GetDateandTime(x, "PostedDate")
                }).ToList()
                .Where(x => ApplyCommentsLogic(x.PostedDate))
                .OrderByDescending(x => x.PostedDate);
            return View("/Views/Altudo/DetailsPage/Review.cshtml", ReviewComments);

        }


        public DateTime GetDateandTime(Item item, string fieldName)

        {
            DateField dateValue = item.Fields[fieldName];
            return dateValue.DateTime;
        }

        private bool ApplyCommentsLogic(DateTime postedDate)
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            var settingsItem = homeItem.Axes.GetDescendants().FirstOrDefault(x => x.TemplateName == "TripCommentsSettings");
           // var settingsItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID("{C2DC814E-7437-4023-99DF-B7AC31863071}"));
            DateField startDate = settingsItem.Fields["StartDate"];
            DateField endDate = settingsItem.Fields["EndDate"];
            return ((postedDate > startDate.DateTime) && (postedDate < endDate.DateTime));
        }
    }

}