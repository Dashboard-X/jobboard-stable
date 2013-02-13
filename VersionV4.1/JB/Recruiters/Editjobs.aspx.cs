using System;
using System.Web.UI.WebControls;

namespace JB.Recruiters
{
    public partial class Editjobs : Clcookiehandler
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

            //edit this page for recs
            var mpgp = new DlMainpagepopulator();
            string recname = mpgp.RecName(Session["pusername"].ToString());

            //check archived
            if (Request.QueryString["archive"] != null)
            {
                if (Request.QueryString["archive"] == "0")
                {
                    GridView1.DataSource = mpgp.GetrecActive(recname, _lowlimit, pagesize);
                    GridView1.DataBind();

                    //set the images
                    Image12.ImageUrl = "/images/red.png";
                    Image11.ImageUrl = "/images/green.png";

                    //get record count
                    maxpages = mpgp.GetrecActivecount(recname);
                }

                else
                {
                    GridView1.DataSource = mpgp.GetrecArchive(recname, _lowlimit, pagesize);
                    GridView1.DataBind();

                    //set the images
                    Image12.ImageUrl = "/images/green.png";
                    Image11.ImageUrl = "/images/red.png";

                    //get record count
                    maxpages = mpgp.GetrecArchivecount(recname);
                }
            }

            else
            {
                //default
                GridView1.DataSource = mpgp.GetrecActive(recname, _lowlimit, pagesize);
                GridView1.DataBind();

                //get record count
                maxpages = mpgp.GetrecActivecount(recname);
            }

            //set pager
            CreatePageLinks(maxpages, pagesize);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["fg"] != null)
            {
                Response.Redirect("/recruiters/editjobs.aspx?archive=0&fg=" + Request.QueryString["fg"]);
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["fg"] != null)
            {
                Response.Redirect("/recruiters/editjobs.aspx?archive=1&fg=" + Request.QueryString["fg"]);
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