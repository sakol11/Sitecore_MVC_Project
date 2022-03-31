using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Project.Altudo.Models
{
    public class LeadershipDetails
    {
        public HtmlString Name { get; set; }
        public HtmlString Age { get; set; }
        public HtmlString Place { get; set; }
        public HtmlString Designation { get; set; }
        public HtmlString WorkedRole { get; set; }
        public HtmlString Term { get; set; }
        public HtmlString KnownFor { get; set; }
        public string SuggestedArticleText { get; set; }
        public string SuggestedArticleUrl { get; set; }
        public string InternalBlogText { get; set; }
        public string InternalBlogUrl { get; set; }
        public HtmlString Image { get; set; }
    }
}