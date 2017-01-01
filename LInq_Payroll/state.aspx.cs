using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LInq_Payroll
{
    public partial class state : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindCOuntries();
                    BindSates();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops Soomething went wrong.')</script>");

            }
        }

        private void BindSates()
        {
            DBPayrollDataContext db = new DBPayrollDataContext();
            var rr = from p in db.tbl_States
                     join p1 in db.tbl_Countries on p.CountryId equals p1.Id
                     select new { p.State, p.Id, p1.CountryName };
            repData.DataSource = rr;
            repData.DataBind();
        }

        private void BindCOuntries()
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
            if (ddlCountry.SelectedIndex != 0)
            {
                if (btnSubmit.Text == "Submit")
                {
                    DBPayrollDataContext db = new LInq_Payroll.DBPayrollDataContext();
                    tbl_State state = new LInq_Payroll.tbl_State();
                    state.CountryId = Convert.ToInt64(ddlCountry.SelectedValue);
                    state.State = txtCountryName.Text;
                    db.tbl_States.InsertOnSubmit(state);
                    db.SubmitChanges();
                }

                if (btnSubmit.Text == "Update")
                {
                    DBPayrollDataContext db = new LInq_Payroll.DBPayrollDataContext();
                    tbl_State state = db.tbl_States.Single(x => x.Id == Convert.ToInt64(ConfigurationManager.AppSettings["EditId"]));
                    state.CountryId = Convert.ToInt64(ddlCountry.SelectedValue);
                    state.State = txtCountryName.Text;
                    db.SubmitChanges();
                    btnSubmit.Text = "Submit";
                    txtCountryName.Text = "";
                    ddlCountry.SelectedIndex = 0;
                }
            }
            BindSates();
        }

        protected void repData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                DBPayrollDataContext db = new LInq_Payroll.DBPayrollDataContext();
                tbl_State state = db.tbl_States.Single(x => x.Id == Convert.ToInt64(e.CommandArgument));
                txtCountryName.Text = state.State;
                ConfigurationManager.AppSettings["EditId"] = state.Id.ToString();
                ddlCountry.SelectedValue = state.CountryId.ToString();
                btnSubmit.Text = "Update";
            }
            if (e.CommandName == "Delete")
            {
                DBPayrollDataContext db = new LInq_Payroll.DBPayrollDataContext();
                tbl_State state = db.tbl_States.Single(x => x.Id == Convert.ToInt64(e.CommandArgument));
                db.tbl_States.DeleteOnSubmit(state);
                db.SubmitChanges();
                BindSates();
            }
        }
    }
}