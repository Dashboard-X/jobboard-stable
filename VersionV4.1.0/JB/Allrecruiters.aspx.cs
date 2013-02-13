using System;

namespace JB
{
    public partial class Allrecruiters : Clpager
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //constructor
            var rcl = new DlRecruiter();

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

            GridView1.DataSource = rcl.Getallrecwithjobs(_lowlimit, pagesize);
            GridView1.DataBind();

            maxpages = rcl.Getrecwjobscount();
            litPaging.Text = CreatePageLinks(maxpages, pagesize);
        }
    }
}