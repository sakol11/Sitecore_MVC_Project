using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.DetailPage.Models
{
    public class DetailPages
    {
        public HtmlString Title  { get; set; }
        public HtmlString Description { get; set; }
        public HtmlString CardImage { get; set; }
        public HtmlString HeroImage { get; set; }
        public string CardUrl { get; set; }
    }
}