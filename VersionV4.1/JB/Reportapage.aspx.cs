using System;
using System.Web.UI;

namespace JB
{
    public partial class reportapage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var spm = new Dlspamfilter();
            var guids = new ClPwdhash();
            spm.Addspamrec(guids.GenerateGuid(), Convert.ToInt32(RadioButtonList1.SelectedItem.Value), spamreasons.Text,
                           Request.ServerVariables["REMOTE_ADDR"], Request.UserAgent,
                           Request.QueryString[0]);
            Session["reasons"] =
                "Thank you for reporting this page, we cannot give individual feed back but we will look into this and may contact you if we require further information.";
            Response.Redirect("confirm.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}