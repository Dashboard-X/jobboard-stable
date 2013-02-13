using System;
using System.Configuration;
using System.Web.UI;

namespace JB.Recruiters
{
    public partial class Login : Clcookiehandler
    {
        private readonly string _cpath = ConfigurationManager.AppSettings["httpspaths"];
        private readonly string _npath = ConfigurationManager.AppSettings["httppaths"];


        protected void Page_Load(object sender, EventArgs e)
        {
            //set default inputs
            TextBox2.Focus();
            Page.Form.DefaultButton = Button2.UniqueID;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var lg = new DlLogins();

            if (TextBox3.Text != string.Empty && TextBox2.Text != string.Empty)
            {
                if (lg.Getuser(TextBox2.Text, TextBox3.Text) == TextBox2.Text)
                {
                    Session["pusername"] = TextBox2.Text;

                    //the below method is overloaded
                    Session["pwelcomename"] = lg.Ewelcomename(TextBox2.Text, 1);

                    string addhash2 = GenerateId();
                    Session["cuserval"] = addhash2;

                    //Response.Redirect("../webform1.aspx");
                    Response.Redirect(_cpath + "/Recruiters/Rechome.aspx?rand=" + addhash2 + "&fg=1");
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(_npath + "/Default.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(_npath + "/Resetpassword.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect(_cpath + "/Recruiters/RecruiterForm.aspx?Fg=2");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect(_npath + "/Default.aspx");
        }
    }
}