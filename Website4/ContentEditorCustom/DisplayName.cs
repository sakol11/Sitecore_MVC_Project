using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Common.ContentEditorCustom
{
    public class DisplayName : Command 
    {
        public override void Execute(CommandContext context)
        {
            var contextItem = context.Items[0];
            if(!(contextItem is null))
            {
                    SheerResponse.Alert($"Display name of selected item is {contextItem.DisplayName}");
            }
        }
    }
}