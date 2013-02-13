using System;
using System.Configuration;
using System.Web.UI;

namespace JB.JobSeekers
{
    public partial class Login : Clcookiehandler
    {
        private readonly string cpath = ConfigurationManager.AppSettings["httpspaths"];
        private readonly string npath = ConfigurationManager.AppSettings["httppaths"];

        //set unset cookies here
        //for all logins
        //add cookie for users

        protected void Page_Load(object sender, EventArgs e)
        {
            //set default inputs
            TextBox2.Focus();
            Page.Form.DefaultButton = Button2.UniqueID;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(npath + "/Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var lg = new DlLogins();

            if (TextBox3.Text != string.Empty && TextBox2.Text != string.Empty)
            {
                if (lg.Getjobuser(TextBox2.Text, TextBox3.Text) == TextBox2.Text)
                {
                    Session["pusername"] = TextBox2.Text;

                    Session["pwelcomename"] = lg.Userwelcomename(TextBox2.Text, 2);

                    string addhash2 = GenerateId();
                    Session["cuserval"] = addhash2;

                    Response.Redirect(cpath + "/Jobseekers/JobSeekerHome.aspx?rand=" + addhash2 + "&crf=2");
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(cpath + "/Resetpassword.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect(cpath + "/Jobseekers/UserApplication.aspx?crf=1");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect(npath + "/Default.aspx");
        }
    }
}