using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace AltudoBatch1.Foundation.Search
{
    public class Templates
    {
        public struct HealthArticle
        {
            public static readonly ID HealthArticleTemplate = new ID("{FADF3CDC-5548-4196-B261-9E784ECAF67B}");
        }

        public struct Field
        {
            public static readonly ID SpecialityName = new ID("{FD560C03-72B0-438A-8200-7FA5868FEC68}");

        }

        public struct SpecialityMaster
        {
            public static readonly ID specialityMasterTemplate = new ID("{BA706418-8360-4509-A42E-787908A8BFC7}");
            public struct Fields
            {
                public static readonly ID specialityNameMaster = new ID("{8E37DD17-EF88-45FB-98E9-2F4A056053FC}");
            }
        }
    }
}