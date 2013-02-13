using System;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace JB.Recruiters
{
    public partial class Rechome : Clcookiehandler
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

            //set zoom levels for all charts
            int xzoom = Convert.ToInt32(zoomer.SelectedItem.Value);

            Chart1.Width = xzoom;

            //get recruiter id
            var clmpop = new DlMainpagepopulator();
            string rectempid = clmpop.RecName(Session["pusername"].ToString());

            //get jobviews made by applicants
            var cljview = new DlJobviewdata();

            Chart1.DataSource = cljview.GetJobviewdata(rectempid);

            Chart1.Series["Series1"].YValueMembers = "jobviews";
            Chart1.Series["Series1"].XValueMember = "dateviewed";

            //customize charting.
            Chart1.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
            Chart1.Series["Series1"].MarkerSize = 3;
            Chart1.Series["Series1"].MarkerColor = Color.Black;
            Chart1.Series["Series1"].ChartType = SeriesChartType.Line;

            //bind data.
            Chart1.DataBind();
        }
    }
}