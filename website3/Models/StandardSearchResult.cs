using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Search.Models
{
    public class StandardSearchResult
    {
        public string SearchTitle { get; set; }
        public string SearchDescription { get; set; }
        public string SearchTitleUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Speciality { get; set; }
    }
}