using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Events;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Common.Handlers
{
    public class SpecialityUpdate
    {
        public void OnItemSave(object sender,EventArgs args)
        {
            Item savedItem = Event.ExtractParameter(args, 0) as Item;

            if (savedItem == null || !"master".Equals(savedItem.Database?.Name, StringComparison.OrdinalIgnoreCase))
                return; if (!savedItem.TemplateID.Equals(Templates.HealthArticle.HealthArticleTemplate))
                return;
            GroupedDroplinkField droplinkField = savedItem.Fields[Templates.Field.SpecialityName];
            var SpecialityCode = droplinkField.TargetItem.Fields[Templates.SpecialityMaster.Fields.specialityCodeMaster].Value;
            using (new SecurityDisabler())
            {
                savedItem.Editing.BeginEdit();
                savedItem.Fields[Templates.Field.SpecialityCode].Value = SpecialityCode;
                savedItem.Editing.EndEdit();
            }


        }
    }
}