using AltudoBatch1.Feature.DetailPage.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Templates;
using Sitecore.Publishing;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltudoBatch1.Feature.DetailPage.Controllers
{
    public class ReviewerFormController : Controller
    {
        // GET: ReviewerForm
       [HttpGet]
        public ActionResult Index()
        {
            ReviewComments reviewForm = new ReviewComments();
            return View("/Views/Altudo/DetailsPage/ReviewForm.cshtml",reviewForm);
        }

        [HttpPost]
        public ActionResult Index(ReviewComments reviewComments)
        {
            var contextItem = Sitecore.Context.Item;
            var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
            var WebDatabase = Sitecore.Configuration.Factory.GetDatabase("web");
            var parentItem = masterDb.GetItem(contextItem.ID);
            ID templateId = new ID("{8C5DD4C2-9DF0-4428-AC65-B54BA1040288}");
            TemplateItem commentTemplate = masterDb.GetTemplate(templateId);
            using ( new SecurityDisabler())
            {
                
                Item newCommentItem = parentItem.Add(reviewComments.Name, commentTemplate);
                newCommentItem.Editing.BeginEdit();
                newCommentItem["Name"] = reviewComments.Name;
                newCommentItem["EmailId"] = reviewComments.EmailId;
                newCommentItem["Rating"] = Convert.ToString(reviewComments.Rating);
                newCommentItem["Comment"] = reviewComments.Comment;
                newCommentItem.Editing.EndEdit();
                PublishOptions publishOptions = new PublishOptions(masterDb, WebDatabase, PublishMode.SingleItem, contextItem.Language, DateTime.Now);
                Publisher publish = new Publisher(publishOptions);
                publish.Options.RootItem = newCommentItem;
                publish.Options.Deep = true;
                publish.Options.Mode = PublishMode.SingleItem;
                publish.Publish();
            };
            
           

            return View("/Views/Altudo/DetailsPage/Thankyou.cshtml", reviewComments);
        }
    }
}