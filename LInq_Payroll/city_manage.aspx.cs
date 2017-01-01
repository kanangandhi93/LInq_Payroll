using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LInq_Payroll
{
    public partial class city_manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountries();
                BindCities();
            }
        }

        private void BindCities()
        {
            try
            {
                DBPayrollDataContext db = new DBPayrollDataContext();
                var rr = from p in db.tbl_Cities
                         join p1 in db.tbl_States on p.StateId equals p1.Id
                         join p2 in db.tbl_Countries on p.CountryId equals p2.Id
                         select new { p.Id, p.City, p1.State, p2.CountryName };
                repData.DataSource = rr;
                repData.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BindCountries()
        {
            try
            {
                DBPayrollDataContext db = new DBPayrollDataContext();
                var rr = from p in db.tbl_Countries
                         select new { p.CountryName, p.Id };
                if (rr.Count() > 0)
                {
                    ddlCountry.DataSource = rr;
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "Id";
                    ddlCountry.DataBind();
                    ddlCountry.Items.Insert(0, "Select Country");
                }
                else
                {
                    Response.Write("<script>alert('Sorry No Country Found.')</script>");
                    Response.Redirect("country.aspx");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops Soomething went wrong.')</script>");

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex != 0 && ddlState.SelectedIndex > 0)
            {
                if (btnSubmit.Text == "Submit")
                {
                    DBPayrollDataContext db = new LInq_Payroll.DBPayrollDataContext();
                    tbl_City city = new LInq_Payroll.tbl_City();
                    city.CountryId = Convert.ToInt64(ddlCountry.SelectedValue);
                    city.StateId = Convert.ToInt64(ddlState.SelectedValue);
                    city.City = txtCountryName.Text;
                    db.tbl_Cities.InsertOnSubmit(city);
                    db.SubmitChanges();
                }

                if (btnSubmit.Text == "Update")
                {
                    DBPayrollDataContext db = new LInq_Payroll.DBPayrollDataContext();
                    tbl_City city = db.tbl_Cities.Single(x => x.Id == Convert.ToInt64(ConfigurationManager.AppSettings["EditId"]));
                    city.CountryId = Convert.ToInt64(ddlCountry.SelectedValue);
                    city.StateId = Convert.ToInt64(ddlState.SelectedValue);
                    city.City = txtCountryName.Text;
                    db.SubmitChanges();
                    btnSubmit.Text = "Submit";
                    txtCountryName.Text = "";
                    ddlCountry.SelectedIndex = 0;
                    ddlState.SelectedIndex = 0;
                }
            }
        }

        protected void repData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                DBPayrollDataContext db = new LInq_Payroll.DBPayrollDataContext();
                tbl_City city = db.tbl_Cities.Single(x => x.Id == Convert.ToInt64(e.CommandArgument));
                txtCountryName.Text = city.City;
                ddlCountry.SelectedValue = city.CountryId.ToString();
                var rr = from p in db.tbl_States
                         where p.CountryId == Convert.ToInt64(ddlCountry.SelectedValue)
                         select new { p.State, p.Id };
                if (rr.Count() > 0)
                {
                    ddlState.DataSource = rr;
                    ddlState.DataTextField = "State";
                    ddlState.DataValueField = "Id";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, "Select State");
                }
                else
                {
                    Response.Write("<script>alert('Sorry No Country Found.')</script>");
                    Response.Redirect("state.aspx");
                }
                ddlState.SelectedValue = city.StateId.ToString();

                ConfigurationManager.AppSettings["EditId"] = city.Id.ToString();
                btnSubmit.Text = "Update";
            }
            if (e.CommandName == "Delete")
            {
                DBPayrollDataContext db = new LInq_Payroll.DBPayrollDataContext();
                tbl_City city = db.tbl_Cities.Single(x => x.Id == Convert.ToInt64(e.CommandArgument));
                db.tbl_Cities.DeleteOnSubmit(city);
                db.SubmitChanges();
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBPayrollDataContext db = new DBPayrollDataContext();
                var rr = from p in db.tbl_States
                         where p.CountryId == Convert.ToInt64(ddlCountry.SelectedValue)
                         select new { p.State, p.Id };
                if (rr.Count() > 0)
                {
                    ddlState.DataSource = rr;
                    ddlState.DataTextField = "State";
                    ddlState.DataValueField = "Id";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, "Select State");
                }
                else
                {
                    Response.Write("<script>alert('Sorry No Country Found.')</script>");
                    Response.Redirect("state.aspx");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops Soomething went wrong.')</script>");
            }
        }
    }
}