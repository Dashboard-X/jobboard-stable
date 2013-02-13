using System;

namespace JB.Recruiters
{
    public partial class Recapplicationdetail : Clcookiehandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //read and validate login
            if (Request.QueryString["rand"] != null)
            {
                if (Session["cuserval"].ToString() == Request.QueryString["rand"])
                {
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }

            else
            {
                Response.Redirect("login.aspx");
            }
            ////////////////////////////////////

            if (Request.QueryString["Applyid"] != null)
            {
                var claps = new DlApps();
                string[] showd = claps.Getapplicationdetails(Request.QueryString["Applyid"]);
                Label2.Text = showd[0];
                HyperLink1.NavigateUrl = Server.MapPath(showd[1]);
            }
        }
    }
}