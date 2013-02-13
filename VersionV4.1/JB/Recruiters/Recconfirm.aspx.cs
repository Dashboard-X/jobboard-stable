using System;
using System.Web.UI;

namespace JB
{
    public partial class Recconfirm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reasonforwarded.Text = "Confirmation";

            if (Session["reasons"] != null)
            {
                textreason.Text = Session["reasons"].ToString();
            }
        }
    }
}