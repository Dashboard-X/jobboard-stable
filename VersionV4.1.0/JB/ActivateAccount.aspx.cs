using System;
using System.Web.UI;

namespace JB
{
    public partial class ActivateAccount : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //activate the account
            if (Request.QueryString["usertype"] != null)
            {
                int usertype = Convert.ToInt16(Request.QueryString["usertype"]);
                string username = Request.QueryString["username"];
                string activation = Request.QueryString["activationid"];

                var cllog = new DlLogins();
                cllog.ActivateAcc(usertype, username, activation);
            }
        }
    }
}