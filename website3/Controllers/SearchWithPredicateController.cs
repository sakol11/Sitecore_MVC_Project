using AltudoBatch1.Feature.Search.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AltudoBatch1.Feature.Search.Controllers
{
    public class SearchWithPredicateController : ApiController
    {
        [Route("altudoapi/SearchWithPredicate")]
        [HttpPost]

       public IHttpActionResult GetSearchResultForPredicate(APIProps SearchParams)
        {
            List<StandardSearchResult> searchResults = new List<StandardSearchResult>();
            var contextDb = Sitecore.Context.Database;
            ISearchIndex searchIndex = ContentSearchManager.GetIndex($"sitecore_{contextDb.Name}_index");
            var searchPredicate = GetSearchPredicate(SearchParams.SearchKey);
            using (IProviderSearchContext searchContext = searchIndex.CreateSearchContext())
            {
                var searchResultFromSolr = searchContext.GetQueryable<SearchOutputModel>()
                    .Where(searchPredicate)
                    .Select(x => new StandardSearchResult
                    {
                        SearchTitle = x.Title,
                        SearchDescription = x.Description,
                    }).ToList();
                searchResults = searchResultFromSolr;
            }

            return Json(searchResults);
        }

        public static Expression<Func<SearchOutputModel,bool>> GetSearchPredicate(string searchTerm)
        {
            var predicate = PredicateBuilder.True<SearchOutputModel>();
            predicate = predicate.And(x => x.TemplateName == "HealthArticle");
            predicate = predicate.Or(x => x.Title.Contains(searchTerm));
            predicate = predicate.Or(x => x.Description.Contains(searchTerm));

            return predicate;

        }
    }
}
