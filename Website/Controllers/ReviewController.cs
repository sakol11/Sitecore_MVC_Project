using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltudoBatch1.Feature.DetailPage.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace AltudoBatch1.Feature.DetailPage.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var contextItem = Sitecore.Context.Item;
            var ReviewComments = contextItem.GetChildren()
                .Where(x => x.TemplateName== "ReviewComment")
                .Select(x => new ReviewComments
                {
                    Name = x.Fields["Name"].Value,
                    EmailId = x.Fields["EmailId"].Value,
                    Comment = x.Fields["Comment"].Value,
                    Rating = Convert.ToInt32(x.Fields["Rating"].Value),
                    PostedDate = GetDateandTime(x, "PostedDate")
                }).ToList()
                .OrderByDescending(x => x.PostedDate);      
                return View("/Views/Altudo/DetailsPage/Review.cshtml",ReviewComments);

        }
        

        public DateTime GetDateandTime(Item item , string fieldName)
        
        {
            DateField dateValue = item.Fields[fieldName];
            return dateValue.DateTime;
        }
    }
}