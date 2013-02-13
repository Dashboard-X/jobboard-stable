using System;
using System.Web.UI.WebControls;

namespace JB.JobSeekers
{
    /// <summary>
    /// This code is liscenced by ahrcloud.com
    /// under free creative common liscence, but
    /// attribution must be made to the author
    /// site at www.ahrcloud.com or info@ahrcloud.com
    /// </summary>
    public partial class Myapplications : Clcookiehandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //read and validate login
            if (Session["cuserval"] != null)
            {
                if (Session["cuserval"].ToString() == Readjobcookie())
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

            int lowlimit = 0;
            int maxpages = 0;
            
            int pagesize = 10;

            if (Request.QueryString["page"] != null)
            {
                lowlimit = (Convert.ToInt16(Request.QueryString["page"]) - 1);
                if (lowlimit != 0)
                {
                    lowlimit = lowlimit * 10;
                }
            }

            //bind grid
            var cmpg = new DlMainpagepopulator();

            var username = Session["pusername"].ToString();

            maxpages = cmpg.Getmyappscount(username);
            
            GridView1.DataSource = cmpg.Getmyapps(username,lowlimit,pagesize);
            GridView1.DataBind();

            //set paging
            CreatePageLinks(maxpages, pagesize);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    e.Row.Attributes.Add("class", "ux_gridrowdb");
                    break;

                default:
                    break;
            }
        }
    }
}