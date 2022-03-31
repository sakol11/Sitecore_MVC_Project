using AltudoBatch1.Feature.Common.Models;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltudoBatch1.Feature.Common.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            var contextitem = Sitecore.Context.Item;
            var homeItemPath = Sitecore.Context.Site.StartPath;
            var HomeItem = Sitecore.Context.Database.GetItem(homeItemPath);
            var breadcrumbList = contextitem.Axes.GetAncestors()
                .Where(x=> x.Axes.IsDescendantOf(HomeItem))
                .Select(x => new BreadcrumbNav
                {
                    NavTitle = x.Name,
                    NavUrl = LinkManager.GetItemUrl(x, new ItemUrlBuilderOptions { LowercaseUrls = true })
                }
                ).ToList()
                .Concat(new List<BreadcrumbNav>()
                {
                    new BreadcrumbNav
                    {
                        NavTitle= contextitem.Name,
                        NavUrl= LinkManager.GetItemUrl(contextitem, new ItemUrlBuilderOptions {LowercaseUrls= true})
                    }
                });
            return View("/Views/Common/Breadcrumb.cshtml", breadcrumbList);
        }
    }
}