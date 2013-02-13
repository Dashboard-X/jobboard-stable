using System;
using System.Collections;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JB
{
    public partial class Default : Clpager
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            var _mp = new DlMainpagepopulator();

            //get salaries
            CheckBoxList6.DataSource = _mp.GetSalary();
            CheckBoxList6.DataTextField = "sTerm";
            CheckBoxList6.DataValueField = "Termid";
            CheckBoxList6.DataBind();

            //get locations
            CheckBoxList2.DataSource = _mp.GetLocations();
            CheckBoxList2.DataTextField = "sTerm";
            CheckBoxList2.DataValueField = "Termid";
            CheckBoxList2.DataBind();

            //get industry
            CheckBoxList1.DataSource = _mp.GetIndustries();
            CheckBoxList1.DataTextField = "sTerm";
            CheckBoxList1.DataValueField = "Termid";
            CheckBoxList1.DataBind();

            if (Request.QueryString["q"] != null & Request.QueryString["q"] != "all")
            {
                TextBox2.Text = Request.QueryString["q"];
            }

            SetSearch();
        }

        private void SetCheckBox(ArrayList __criteria)
        {
            foreach (string criterion in __criteria)
            {
                foreach (ListItem _cbx in CheckBoxList1.Items)
                {
                    if (_cbx.Value == criterion)
                    {
                        CheckBoxList1.Items.FindByValue(criterion).Selected = true;
                    }
                }

                foreach (ListItem _cbx in CheckBoxList2.Items)
                {
                    if (_cbx.Value == criterion)
                    {
                        CheckBoxList2.Items.FindByValue(criterion).Selected = true;
                    }
                }

                foreach (ListItem _cbx in CheckBoxList3.Items)
                {
                    if (_cbx.Value == criterion)
                    {
                        CheckBoxList3.Items.FindByValue(criterion).Selected = true;
                    }
                }

                foreach (ListItem _cbx in CheckBoxList4.Items)
                {
                    if (_cbx.Value == criterion)
                    {
                        CheckBoxList4.Items.FindByValue(criterion).Selected = true;
                    }
                }

                foreach (ListItem _cbx in CheckBoxList5.Items)
                {
                    if (_cbx.Value == criterion)
                    {
                        CheckBoxList5.Items.FindByValue(criterion).Selected = true;
                    }
                }


                foreach (ListItem _cbx in CheckBoxList6.Items)
                {
                    if (_cbx.Value == criterion)
                    {
                        CheckBoxList6.Items.FindByValue(criterion).Selected = true;
                    }
                }
            }
        }

        private void SetSearch()
        {
            var _sr = new DlSearchfilters();
            var _cr = new Dlsearchhelper();

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

            if (Request.QueryString["q"] != null)
            {
                if (Request.QueryString["q"] == "all")
                {
                    GridView1.DataSource = _sr.GetJobssingle(_lowlimit, pagesize);
                    GridView1.DataBind();

                    maxpages = _sr.Getalljobcount();
                }

                else if (Request.QueryString["filter"] != null)
                {
                    //textbox+criteria
                    var _criteria = (ArrayList) Session["criteria"];
                    string _title = Request.QueryString["q"];

                    GridView1.DataSource = _cr.Applytitlefilter(_title, _criteria, _lowlimit, pagesize);
                    GridView1.DataBind();

                    //get total jobs
                    maxpages = _cr.Applytitlefiltercount(_title, _criteria, _lowlimit, pagesize);

                    //set checkboxes
                    SetCheckBox(_criteria);

                    //show filters
                    ClearFilters.Visible = true;
                }

                else
                {
                    //textbox only
                    string __title = Request.QueryString["q"];

                    GridView1.DataSource = _cr.Applytitlefilter(__title, _lowlimit, pagesize);
                    GridView1.DataBind();

                    //get total jobs
                    maxpages = _cr.Applytitlefiltercount(__title, _lowlimit, pagesize);

                    //show filters
                    ClearFilters.Visible = true;
                }
            }

            else
            {
                if (Request.QueryString["filter"] == null)
                {
                    GridView1.DataSource = _sr.GetJobssingle(_lowlimit, pagesize);
                    GridView1.DataBind();

                    maxpages = _sr.Getalljobcount();
                }

                else
                {
                    //criteria only
                    var _criteria = (ArrayList) Session["criteria"];

                    GridView1.DataSource = _cr.Applycriteriafilter(_criteria, _lowlimit, pagesize);
                    GridView1.DataBind();

                    //get total jobs
                    maxpages = _cr.Applycriteriafiltercount(_criteria, _lowlimit, pagesize);

                    //setcheckbox
                    SetCheckBox(_criteria);

                    //show filter button
                    ClearFilters.Visible = true;
                }
            }

            var rec = new DlRecruiter();

            //get count of all jobs filtered
            Label13.Text = maxpages + " Jobs Advertized by " + rec.Getcountrecswadvert() + " Recruiters ";

            //set pager
            litPaging.Text = CreatePageLinks(maxpages, pagesize);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //featured Recruiters
            var _frec = new DlFeaturedrecruiters();
            GridView2.DataSource = _frec.GetFRecs();
            GridView2.DataBind();

            //set default inputs
            TextBox2.Focus();
            Form.DefaultButton = Button1.UniqueID;
        }

        private ArrayList Shortbuildfunc()
        {
            var shortbuild = new ArrayList();

            //insert salaries
            foreach (ListItem listite in CheckBoxList6.Items.Cast<ListItem>().Where(listite => listite.Selected))
            {
                shortbuild.Add(listite.Value);
            }

            //insert location
            foreach (ListItem listite1 in CheckBoxList2.Items.Cast<ListItem>().Where(listite1 => listite1.Selected))
            {
                shortbuild.Add(listite1.Value);
            }

            //industry
            foreach (ListItem listit2 in CheckBoxList1.Items.Cast<ListItem>().Where(listit2 => listit2.Selected))
            {
                shortbuild.Add(listit2.Value);
            }

            //insert contract
            foreach (ListItem listit3 in CheckBoxList3.Items.Cast<ListItem>().Where(listit3 => listit3.Selected))
            {
                shortbuild.Add(listit3.Value);
            }

            //add hours
            foreach (ListItem listit4 in CheckBoxList4.Items.Cast<ListItem>().Where(listit4 => listit4.Selected))
            {
                shortbuild.Add(listit4.Value);
            }

            //add employer type
            foreach (ListItem listit5 in CheckBoxList5.Items.Cast<ListItem>().Where(listit5 => listit5.Selected))
            {
                shortbuild.Add(listit5.Value);
            }

            return shortbuild;
        }

        private void RedirectSearch()
        {
            ArrayList _tempsearch = Shortbuildfunc();

            //clear current session
            Session.Remove("criteria");

            if (_tempsearch.Count > 0)
            {
                Session["criteria"] = _tempsearch;

                if (TextBox2.Text.Trim() != "")
                {
                    //textbox + criteria
                    Response.Redirect("/default.aspx?q=" + TextBox2.Text.Trim() + "&filter=true");
                }
                else
                {
                    //only checkbox in criteria
                    Response.Redirect("/default.aspx?filter=true");
                }
            }

            else
            {
                if (TextBox2.Text.Trim() != "")
                {
                    Response.Redirect("/default.aspx?q=" + TextBox2.Text.Trim());
                }

                else
                {
                    //perform only title search
                    Response.Redirect("/default.aspx?q=all");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RedirectSearch();
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

        protected void LinkButton44_Click(object sender, EventArgs e)
        {
            Response.Redirect("/contact.aspx");
        }

        protected void LinkButtonj_Click(object sender, EventArgs e)
        {
            Response.Redirect("/allRecruiters.aspx");
        }

        protected void LinkButtona6_Click(object sender, EventArgs e)
        {
            Response.Redirect("/default.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/jbsubscribe.aspx");
        }

        protected void ClearFilters_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/default.aspx");
        }
    }
}