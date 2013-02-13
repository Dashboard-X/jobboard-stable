using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;

namespace JB.Adapters
{
    public class GridViewAdapter : ControlAdapter
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var gv = Control as GridView;

            if (gv != null && gv.Rows.Count > 0)
            {
                foreach (GridViewRow grv in gv.Rows)
                {
                    writer.Indent++;
                    writer.WriteBeginTag("div");

                    if (grv.HasAttributes)
                    {
                        grv.Attributes.Render(writer);
                    }

                    writer.Write(HtmlTextWriter.TagRightChar);

                    if (!String.IsNullOrEmpty(grv.CssClass))
                    {
                        writer.AddAttribute("class", grv.CssClass);
                    }

                    foreach (Control ctrl in from TableCell tcell in grv.Cells from Control ctrl in tcell.Controls select ctrl)
                    {
                        ctrl.RenderControl(writer);
                    }

                    writer.WriteEndTag("div");
                    writer.Indent--;
                    writer.WriteLine();
                }

                
            }
        }
    }
}