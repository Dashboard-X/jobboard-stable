using System;
using System.Web.UI;

namespace JB
{
    public partial class Logoff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/default.aspx");
        }
    }
}