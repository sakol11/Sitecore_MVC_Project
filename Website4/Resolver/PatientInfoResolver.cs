using Newtonsoft.Json.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Common.Resolver
{
    public class PatientInfoResolver: RenderingContentsResolver
    {

        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var contextitem = GetContextItem(rendering, renderingConfig);
            var patientName = contextitem.Fields["patientName"];
            var patientGender = contextitem.Fields["patientGender"];
            JObject jObject = new JObject()
            {
                ["patientName"] = patientName.Value,
                ["patientGender"] = patientGender.Value

            };
            return jObject;
        }
       
    }
}