using System;
using System.Configuration;
using System.Web.UI;

namespace JB
{
    public partial class JOB : MasterPage
    {
        private readonly string cpath = ConfigurationManager.AppSettings["httpspaths"];

        protected void Page_Load(object sender, EventArgs e)
        {
            //LinkButton5.Visible = false;

            if (Session["pusername"] != null)
            {
                string storsess = Session["pusername"].ToString();

                var clls = new DlLogins();

                //this is recruiter
                if (clls.Checkusertype(storsess, 1) == 1)
                {
                    LinkButton1.Text = storsess + "'s cpanel";
                    LinkButton2.Enabled = false;
                    LinkButton2.CssClass = "Styleag1";
                }

                    //this is a normal user
                else
                {
                    LinkButton2.Text = storsess + "'s cpanel";
                    LinkButton1.Enabled = false;
                    LinkButton1.CssClass = "Styleag1";
                }

                //check recruiters
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (LinkButton1.Text.Contains("cpanel"))
            {
                Response.Redirect(cpath + "/Recruiters/Rechome.aspx?fg=1&rand=" + Request.QueryString["rand"]);
            }

            else
            {
                Response.Redirect(cpath + "/Recruiters/Login.aspx");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (LinkButton2.Text.Contains("cpanel"))
            {
                Response.Redirect(cpath + "/JobSeekers/Jobseekerhome.aspx?crf=2&rand=" + Request.QueryString["rand"]);
            }

            else
            {
                Response.Redirect(cpath + "/JobSeekers/Login.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/classified/");
        }
    }
}