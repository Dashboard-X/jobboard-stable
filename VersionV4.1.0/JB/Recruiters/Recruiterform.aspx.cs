using System;
using System.Configuration;
using System.IO;

namespace JB.Recruiters
{
    public partial class RecruiterForm : Clcookiehandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //set default inputs
            TextBox2.Focus();
            Page.Form.DefaultButton = Button2.UniqueID;

            if (!IsPostBack)
            {
                if (Session["pusername"] != null)
                {
                    int fg = Convert.ToInt16(Request.QueryString["Fg"]);

                    var mpage = new DlMainpagepopulator();

                    string recsid = mpage.RecName(Session["pusername"].ToString());

                    if (fg == 1)
                    {
                        //disable required fields
                        RequiredFieldValidator9.Enabled = false;
                        RequiredFieldValidator11.Enabled = false;

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

                        string[] arr = mpage.RecDetails(Session["pusername"].ToString());

                        TextBox2.Text = arr[0];
                        TextBox3.Text = arr[1];

                        TextBox10.Text = arr[2];

                        TextBox4.Text = arr[3];
                        TextBox5.Text = arr[4];
                        TextBox6.Text = arr[5];

                        TextBox7.Text = arr[6];
                        TextBox8.Text = arr[7];

                        //TextBox9.Text = arr[8];
                        TextBox9.Text = arr[8];

                        TextBox12.Text = arr[9];
                        TextBox13.Text = arr[10];

                        TextBox11.Text = Session["pusername"].ToString();
                        TextBox11.Enabled = false;

                        TextBox14.Text = arr[14];
                        TextBox16.Text = arr[13];

                        TextBox15.Text = arr[12];

                        TextBox12.Enabled = false;
                        TextBox13.Enabled = false;
                        TextBox17.Enabled = false;
                        Button3.Visible = false;

                        PanelSignup.Visible = false;
                        Panel1.Visible = false;
                    }

                    // featured recurites
                    var frs = new DlFeaturedrecruiters();

                    //get recruters image
                    Image8.Visible = true;
                    Image8.ImageUrl = frs.Getrecformimage(recsid);
                }

                else
                {
                    Image8.Visible = false;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var lgeins = new DlLogins();

            if (Request.QueryString["Fg"] != null)
            {
                string _fg = Request.QueryString["Fg"];

                if (_fg == "1")
                {
                    //update
                    //update user rec information
                    var _rcl = new DlRecruiter();

                    _rcl.Runrecuserupdate(TextBox2.Text, TextBox3.Text, Session["pusername"].ToString());

                    //get current article id for the logo.
                    int tmpartid = _rcl.Getarticleids(Session["pusername"].ToString());

                    //save to hlogo
                    string hlogo = "";

                    //update logo
                    if (FileUpload1.HasFile)
                    {
                        hlogo = Server.MapPath(ConfigurationManager.AppSettings["filepath"]) + tmpartid +
                                FileUpload1.FileName;

                        //update articles
                        FileUpload1.SaveAs(hlogo);
                    }

                    //update articles in db
                    _rcl.Runreclogoupdate(hlogo, "Recruiter Logo", Session["pusername"].ToString());

                    //update recruiters own information
                    _rcl.Runrectableupdate(TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text,
                                           TextBox8.Text,
                                           TextBox9.Text, TextBox10.Text, TextBox15.Text, TextBox16.Text,
                                           TextBox14.Text, Session["pusername"].ToString());

                    //update message
                    Session["reasons"] = "Profile Updated Sucessfully!";
                    Response.Redirect("Recconfirm.aspx?fg=1&rand=" + Request.QueryString["rand"]);
                }
            }

            else
            {
                if (capts.Text == Session["capts"].ToString())
                {
                    var dl = new DlRecruiter();

                    if (lgeins.Checkrecusern(TextBox11.Text) != TextBox11.Text && dl.Getrecid(TextBox10.Text) == "0")
                    {
                        //insert
                        var mps = new DlMainpagepopulator();
                        var pwds = new ClPwdhash();
                        var arc = new DlArticles();

                        string getmaxrec = pwds.GenerateGuid();
                        string getmaxrecarticles = pwds.GenerateGuid();
                        string getmaxrecuserid = pwds.GenerateGuid();

                        string shahsp = pwds.GetMd5Hash(Guid.NewGuid().ToString().Replace("-", ""));

                        //set email body
                        var emaps = new DlEmailprocessor();

                        string ebod1 =
                            emaps.Emailactivateusr("https://itcareers.com/ActivateAccount.aspx?activationid=" + shahsp +
                                                   "&usertype=1&username=" + TextBox11.Text, TextBox11.Text).ToString();

                        //recruiters
                        mps.Insertrecruiters(getmaxrec, TextBox10.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text,
                                             TextBox7.Text, TextBox8.Text, "GB", TextBox9.Text, TextBox11.Text,
                                             TextBox15.Text, TextBox16.Text, TextBox14.Text,
                                             1, getmaxrecarticles);

                        //users and pwds
                        string md5h = pwds.GetMd5Hash(TextBox12.Text);
                        mps.Insertusers(TextBox11.Text, TextBox2.Text, 1, TextBox3.Text, md5h, 1, getmaxrecuserid,
                                        "hint", "-1", shahsp);

                        //employee logo
                        string holdlogo = Path.GetFileName(FileUpload1.FileName);

                        arc.AddArticle(getmaxrecarticles, holdlogo,
                                       ConfigurationManager.AppSettings["filepath"] + getmaxrecarticles + holdlogo);

                        //real upload
                        FileUpload1.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["filepath"]) +
                                           getmaxrecarticles +
                                           holdlogo);

                        //user recruiter assignments
                        mps.Insertrecusermapping(getmaxrecuserid, getmaxrec);

                        //finally send out the email
                        emaps.Clemail.Sendmailproc(TextBox11.Text, "ahrcloud.com: Account Activation!", ebod1, 4);

                        //logg it as the entry for email
                        emaps.Sendappemaildbupdate(pwds.GenerateGuid(), TextBox11.Text, 1);

                        //redirect
                        Session["reasons"] = "Please continue to login with your details!";
                        Response.Redirect("Recconfirm.aspx");
                    }

                    else
                    {
                        //user already exists
                        Label24.Visible = true;
                    }
                }
                else
                {
                    Label31.Text = "please retype the captcha as shown in grey box!";
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}