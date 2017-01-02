using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LInq_Payroll
{
    public partial class company_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindCountries();
                    BindCompany();
                }
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
            try
            {
                DBPayrollDataContext db = new DBPayrollDataContext();
                if (btnSubmit.Text == "Submit")
                {
                    if (FuImg.HasFile)
                    {
                        string str = FuImg.FileName;
                        FuImg.PostedFile.SaveAs(Server.MapPath("~/company_logo/" + str));
                        string Image = "~/company_logo/" + str.ToString();
                        tbl_CompanyDetail company = new tbl_CompanyDetail()
                        {
                            AddressLine1 = txtAdd1.Text,
                            AddressLine2 = txtAdd2.Text,
                            AddressLine3 = txtAdd3.Text,
                            City = ddlcity.SelectedValue,
                            CompanyLogo = Image,
                            CompanyName = txtCompanyName.Text,
                            ContactNo1 = Convert.ToDecimal(txtContactNo1.Text),
                            ContactNo2 = Convert.ToDecimal(txtContactNo2.Text),
                            Country = ddlCountry.SelectedValue,
                            CreateDate = System.DateTime.Now,
                            CUser = 1,
                            EmailId = txtEmail.Text,
                            FaxNo = Convert.ToDecimal(txtFax.Text),
                            FoundedYear = Convert.ToInt64(txtFYear.Text),
                            Founder1 = txtFounder1.Text,
                            PostalCode = txtPostalCode.Text,
                            State = ddlState.SelectedValue
                        };
                        db.tbl_CompanyDetails.InsertOnSubmit(company);
                        db.SubmitChanges();
                        BindCompany();
                    }
                    else
                    {
                        tbl_CompanyDetail company = new tbl_CompanyDetail()
                        {
                            AddressLine1 = txtAdd1.Text,
                            AddressLine2 = txtAdd2.Text,
                            AddressLine3 = txtAdd3.Text,
                            City = ddlcity.SelectedValue,
                            CompanyName = txtCompanyName.Text,
                            ContactNo1 = Convert.ToDecimal(txtContactNo1.Text),
                            ContactNo2 = Convert.ToDecimal(txtContactNo2.Text),
                            Country = ddlCountry.SelectedValue,
                            CreateDate = System.DateTime.Now,
                            CUser = 1,
                            EmailId = txtEmail.Text,
                            FaxNo = Convert.ToDecimal(txtFax.Text),
                            FoundedYear = Convert.ToInt64(txtFYear.Text),
                            Founder1 = txtFounder1.Text,
                            PostalCode = txtPostalCode.Text,
                            State = ddlState.SelectedValue
                        };
                        db.tbl_CompanyDetails.InsertOnSubmit(company);
                        db.SubmitChanges();
                        BindCompany();
                    }
                }

                if (btnSubmit.Text == "Update")
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BindCompany()
        {
            DBPayrollDataContext db = new DBPayrollDataContext();
            var rr = from p in db.tbl_CompanyDetails
                     select p;
            if (rr.Count() > 0)
            {
                txtAdd1.Text = rr.First().AddressLine1;
                txtAdd2.Text = rr.First().AddressLine2;
                txtAdd3.Text = rr.First().AddressLine3;
                txtCompanyName.Text = rr.First().CompanyName;
                txtContactNo1.Text = rr.First().ContactNo1.ToString();
                txtContactNo2.Text = rr.First().ContactNo2.ToString();
                txtEmail.Text = rr.First().EmailId.ToString();
                txtFax.Text = rr.First().FaxNo.ToString();
                txtFounder1.Text = rr.First().Founder1;
                txtFYear.Text = rr.First().FoundedYear.ToString();
                txtPostalCode.Text = rr.First().PostalCode.ToString();
                btnSubmit.Text = "Update";
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

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBPayrollDataContext db = new DBPayrollDataContext();
                var rr = from p in db.tbl_Cities
                         where p.StateId == Convert.ToInt64(ddlState.SelectedValue)
                         select new { p.City, p.Id };
                if (rr.Count() > 0)
                {
                    ddlcity.DataSource = rr;
                    ddlcity.DataTextField = "City";
                    ddlcity.DataValueField = "Id";
                    ddlcity.DataBind();
                    ddlcity.Items.Insert(0, "Select City");
                }
                else
                {
                    Response.Write("<script>alert('Sorry No Country Found.')</script>");
                    Response.Redirect("city_manage.aspx");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops Soomething went wrong.')</script>");
            }
        }
    }
}