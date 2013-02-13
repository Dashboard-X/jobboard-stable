using System;
using System.Web.UI.WebControls;

namespace JB.Recruiters
{
    public partial class RecApplication : Clcookiehandler
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

            if (Session["pusername"] != null)
            {
                //get employer id
                var mpg = new DlMainpagepopulator();
                string emid = mpg.RecName(Session["pusername"].ToString());
                var app = new DlApps();

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

                maxpages = app.GetApplicationcount(emid);

                //bind to grid
                GridView1.DataSource = app.GetApplication(emid, _lowlimit, pagesize);
                GridView1.DataBind();

                //set paging
                CreatePageLinks(maxpages, pagesize);
            }
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