using System;
using System.Web.UI.WebControls;

namespace JB.JobSeekers
{
    public partial class Myapplications : Clcookiehandler
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

            int _lowlimit = 0;
            int maxpages = 0;

            const int pagesize = 10;

            if (Request.QueryString["page"] != null)
            {
                _lowlimit = (Convert.ToInt16(Request.QueryString["page"]) - 1);
                if (_lowlimit != 0)
                {
                    _lowlimit = _lowlimit*10;
                }
            }

            //bind grid
            var cmpg = new DlMainpagepopulator();

            string username = Session["pusername"].ToString();

            maxpages = cmpg.Getmyappscount(username);

            GridView1.DataSource = cmpg.Getmyapps(username, _lowlimit, pagesize);
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