using AltudoBatch1.Project.Altudo.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AltudoBatch1.Project.Altudo.Controllers
{
    public class LeadershipDetailsController : Controller
    {
        // GET: LeadershipDetails
        public ActionResult Index()
        {
            LeadershipDetails leaderShipDetail ;
             var contextItem = Sitecore.Context.Item;
            var renderingItem = RenderingContext.Current.Rendering.Item;
            if (renderingItem == null)
            {
                renderingItem = RenderingContext.Current.ContextItem;
                leaderShipDetail = new LeadershipDetails();
            }

            else {
                LinkField linkField = renderingItem.Fields["SuggestedArticle"];
                LinkField internalLink = renderingItem.Fields["InternalBlog"];
                var targetItem = internalLink.TargetItem;
                leaderShipDetail = new LeadershipDetails
                {
                    Name = new HtmlString(FieldRenderer.Render(renderingItem, "Name")),
                    Age = new HtmlString(contextItem.Fields["Age"].Value),  /*not allowed to edit in expereicne editor*/
                    Place = new HtmlString(FieldRenderer.Render(renderingItem, "Place")),
                    Designation = new HtmlString(FieldRenderer.Render(renderingItem, "Designation")),
                    WorkedRole = new HtmlString(FieldRenderer.Render(renderingItem, "WorkedRole")),
                    Term = new HtmlString(FieldRenderer.Render(renderingItem, "Term")),
                    KnownFor = new HtmlString(FieldRenderer.Render(renderingItem, "KnownFor")),
                    SuggestedArticleUrl = linkField.Url,
                    SuggestedArticleText = linkField.Title,
                    InternalBlogUrl = LinkManager.GetItemUrl(targetItem),
                    InternalBlogText = targetItem.Fields["Name"].Value

                };

            }
            return View("/Views/LeadershipDetails/LeadershipDetails.cshtml",leaderShipDetail);
        }

        public ActionResult DisplayLeaders()

        {
            var contextItem = Sitecore.Context.Item;
            List<LeadershipDetails> leadersList = new List<LeadershipDetails>();
            MultilistField AddedLeaders = contextItem.Fields["LeadersList"];
            leadersList = AddedLeaders.GetItems().Select(leader => new LeadershipDetails
            {
                Name = new HtmlString(FieldRenderer.Render(leader, "Name")),
                Age = new HtmlString(FieldRenderer.Render(leader, "Age")),
                Place = new HtmlString(FieldRenderer.Render(leader, "Place")),
                Designation = new HtmlString(FieldRenderer.Render(leader, "Designation")),
                WorkedRole = new HtmlString(FieldRenderer.Render(leader, "WorkedRole")),
                Image = new HtmlString(FieldRenderer.Render(leader, "Image"))
            }).ToList();
            return View("/Views/LeaderProfile/LeaderList.cshtml",leadersList);

        }
    }
}