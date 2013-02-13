using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JB
{
    /// <summary>
    /// This code is liscenced by ahrcloud.com
    /// under free creative common liscence, but
    /// attribution must be made to the author
    /// site at www.ahrcloud.com or info@ahrcloud.com
    /// </summary>
    public partial class Allrecruiters : Clpager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //constructor
            var rcl = new DlRecruiter();
            
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

            GridView1.DataSource = rcl.Getallrecwithjobs(lowlimit, pagesize);
            GridView1.DataBind();

            maxpages = rcl.Getrecwjobscount();
            litPaging.Text = CreatePageLinks(maxpages, pagesize);

        }
    }
}