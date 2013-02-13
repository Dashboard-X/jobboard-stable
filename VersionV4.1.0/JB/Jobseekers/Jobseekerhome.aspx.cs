using System;

namespace JB.JobSeekers
{
    public partial class JobSeekerHome : Clcookiehandler
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
        }
    }
}