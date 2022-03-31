using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltudoBatch1.Feature.Common.ContentEditorCustom
{
    public class TemplateName : Command
    {
        public override void Execute(CommandContext context)
        {
            var contextItem = context.Items[0];
            if (!(contextItem.TemplateName is null))
            {
                SheerResponse.Alert($"Template name of selected item is {contextItem.TemplateName}");
            }
            else
            {
                SheerResponse.Alert($"No template is present for the selected item");
            }
        }
    }
}