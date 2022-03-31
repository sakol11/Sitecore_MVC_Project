using AltudoBatch1.Feature.Search.Models;
using Sitecore.ContentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltudoBatch1.Feature.Search.Controllers
{
    public class StandardSearchController : ApiController
    {
        [Route("altudoapi/StandardSearch")]
        [HttpPost]

        public IHttpActionResult GetStandardSearchResults(APIProps searchkey )
        
        {
            List<StandardSearchResult> searchResults = new List<StandardSearchResult>();
            var contextDb = Sitecore.Context.Database;
            ISearchIndex searchIndex = ContentSearchManager.GetIndex($"sitecore_{contextDb.Name}_index");

            using (IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
            {
                var searchResultFromSolr = searchContext.GetQueryable<SearchOutputModel>()
                    .Where(x => x.TemplateName == "HealthArticle")
                    .Where(x => x.Title.Contains(searchkey.SearchKey))
                    .Where(x => x.Description.Contains(searchkey.SearchKey))
                    .Select(x => new StandardSearchResult
                    {
                        SearchTitle = x.Title,
                        SearchDescription = x.Description,
                        SearchTitleUrl=x.ArticleUrl,
                        ImageUrl=x.SearchMediaUrl,
                        Speciality=x.SpecialityName
                       
                    }).ToList();
                searchResults = searchResultFromSolr;
            }

            return Json(searchResults);
        }
    }
}
