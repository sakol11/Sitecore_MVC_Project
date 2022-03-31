using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltudoBatch1.Feature.Search.Controllers
{
    public class SearchApiController : ApiController
    {   
        [HttpPost]
        [Route("altudoapi/HandleSearch")]
        public IHttpActionResult HandleSearch(APIProps SearchString)
        {
            List<searchResult> searchResults = new List<searchResult>();
            var contextDb = Sitecore.Context.Database;
            ISearchIndex searchIndex = ContentSearchManager.GetIndex($"sitecore_{contextDb.Name}_index");

            using (IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
            {
                var searchResultFromSolr = searchContext.GetQueryable<SearchResultItem>()
                    .Where(x => x.TemplateName == "HealthArticle")
                    .Where(x => x.Content.Contains(SearchString.SearchKey))
                    .Select(x => new searchResult
                    {
                        SearchTitle = Convert.ToString(x.Fields["title_t"]),
                        SearchDescription = Convert.ToString(x.Fields["breif_t"]),
                    }).ToList();
                searchResults = searchResultFromSolr;
            }


                //searchResult searchRes1 = new searchResult();
            //searchRes1.SearchDescription = "Description for search 1";
            //searchRes1.SearchTitle = "Title search 1";
            //searchRes1.SearchTitle = "http://altudoapp.dev.local/";
            return Json(searchResults);
        }
      
    }
    public class searchResult
    {
        public string SearchTitle { get; set; }
        public string SearchDescription { get; set; }
        public string SearchTitleUrl { get; set; }

    }
    public class APIProps
    {
       public string SearchKey { get; set; }
    }
}
