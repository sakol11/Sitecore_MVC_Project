using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Foundation.Search.ComputedIndexes
{
    public class ArticleSpeciality : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item sitecoreItem = indexable as SitecoreIndexableItem;
            if (sitecoreItem == null)
                return null;
            if (sitecoreItem.TemplateID != Templates.HealthArticle.HealthArticleTemplate)
                return null;
            GroupedDroplinkField droplinkField = sitecoreItem.Fields[Templates.Field.SpecialityName];
          return  droplinkField.TargetItem.Fields[Templates.SpecialityMaster.Fields.specialityNameMaster].Value;
        }

    }
}