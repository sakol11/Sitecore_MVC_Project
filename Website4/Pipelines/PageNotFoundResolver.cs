using Sitecore.Data;
using Sitecore.Pipelines.HttpRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Common.Pipelines
{
    public class PageNotFoundResolver : HttpRequestProcessor
    {
        public override void Process(HttpRequestArgs args)
        {
            if (args.Url.FilePath.Contains("/sitecore") || File.Exists(args.Url.FilePath) || args.Url.FilePath.Contains("altudoapi"))
                return;
            var contextItem = Sitecore.Context.Item;
            if(contextItem is null)
            {
                var PageNotFoundItem = Sitecore.Context.Database.GetItem(new ID("{A845461A-FD76-4408-943A-8BBCE42127B9}"));
                Sitecore.Context.Item = PageNotFoundItem;
            }
            //fetch the context item
            //check context item is null
            //if its null fetch page not found item
            //set your context item with page not found item

        }

    }
}