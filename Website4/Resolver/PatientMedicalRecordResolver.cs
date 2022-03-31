using Newtonsoft.Json.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
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
    public class PatientMedicalRecordResolver : RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var contextitem = GetContextItem(rendering, renderingConfig);
            MultilistField patientRecordsList = contextitem.Fields["Records"];
            JObject jObject = new JObject()
            {
                ["Records"] = (JToken)new JArray()
        };
            var patientRecordItems = patientRecordsList
            .GetItems()
        .Select(x => ExtractRecordFieldFromItem(x))
                                .ToList();
            jObject["Records"] = ProcessItems(patientRecordItems, rendering, renderingConfig);
            return jObject;
        }
        private Item ExtractRecordFieldFromItem(Item item)
        {
            var fakeId = new ID();
            //create an item definition
            var def = new ItemDefinition
            (fakeId,
            item.Name,
            new ID("{B6517AD2-9F0C-424E-B19C-FAFC6F1987D9}"), //template id
            ID.Null);
            //extract fields
            var fields = new FieldList();
            fields.Add(new ID("{36167744-3206-4AA1-A036-688FAB98BC6D}"), item.Fields["Prescription"].Value);
            //assemble the item data
            var data = new ItemData(def, Language.Current, Sitecore.Data.Version.First, fields);
            //instantiate using the definition and data
            var resultItem = new Item(fakeId, data, Sitecore.Context.Database);
            return resultItem;
        }
    }


}