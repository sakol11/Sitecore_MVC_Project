using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Common.ContentEditorCustom
{
    public class ChildItemCount:Command
    {
        public override void Execute(CommandContext context)
        {
            Item contextItem = context.Items[0];
            if(!(contextItem is null))
            {
                if(contextItem.HasChildren)
                {
                    SheerResponse.Alert($"The child item count for the selected item is {contextItem.Children.Count}");
                }
                else
                {
                    SheerResponse.Alert($"There is no child item available for the selected item");
                }
            }
        }
    }
}