using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltudoBatch1.Project.Altudo.Controllers
{
    public class ArticlesController : ApiController
    {
        [Route("altudoapi/GetArticles")]
        public IHttpActionResult GetArticles()
        {
            var contextItem = Sitecore.Configuration.Factory.GetDatabase(Constants.DatabaseName).GetItem(Constants.ArticleID);

            var listofArticles = contextItem.GetChildren()
            .Select(x => new JsonArticle
            {
                Name = x.Name,
                Title = x.Fields["Title"].Value,
                Breif = x.Fields["Breif"].Value,
                ImageUrl = GetImageUrl(x, "ArticleImage")
            })
            .ToList();
            return Json(listofArticles);
        }
        private string GetImageUrl(Item item,string fieldName)
        {
            ImageField image = item.Fields[fieldName];
            return MediaManager.GetMediaUrl(image.MediaItem);
        }
        [Route("altudoapi/GetCarouselArticles")]
        public IHttpActionResult GetCarouselItems()
        {
            var contextItem = Sitecore.Configuration.Factory.GetDatabase(Constants.DatabaseName).GetItem(Constants.ArticleID);
            var listofArticles = contextItem.GetChildren()
           .Select(x => new CarouselArticle
           {
               CarouselName = x.Name,
               CarouselTitle = x.Fields["Title"].Value,
               CarouselImageUrl = GetImageUrl(x, "CarouselImage")
           })
           .ToList();
            return Json(listofArticles);

        }
    }
   
    public class JsonArticle
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Breif { get; set; }
        public string ImageUrl { get; set; }
      
    }

    public class CarouselArticle
    {
        public string CarouselName { get; set; }
        public string CarouselTitle { get; set; }
        public string CarouselImageUrl { get; set; }

    }
}

