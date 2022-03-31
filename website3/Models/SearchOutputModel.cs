using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Search.Models
{
    public class SearchOutputModel : SearchResultItem
    {
        [IndexField("title_t")]
        public string Title { get; set; }
        [IndexField("breif_t")]
        public string Description { get; set; }
        [IndexField("articleurl_s")]
        public string ArticleUrl { get; set; }
        [IndexField("articleimageurl_s")]
        public string SearchMediaUrl {get;set;}
        [IndexField("articlespeciality_s")]
        public string SpecialityName { get; set; }
        
    }
}