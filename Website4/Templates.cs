using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Common
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
            public static readonly ID SpecialityCode = new ID("{F02E5A7A-DA59-495F-BC62-08764F6776A5}");

        }

        public struct SpecialityMaster
        {
            public static readonly ID specialityMasterTemplate = new ID("{BA706418-8360-4509-A42E-787908A8BFC7}");
            public struct Fields
            {
                public static readonly ID specialityCodeMaster = new ID("{389F2315-56D6-48F3-A70E-7C5E83F2A7FC}");
            }
        }

    }
}