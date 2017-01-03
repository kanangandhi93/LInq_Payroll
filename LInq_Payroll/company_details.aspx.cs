using System;
using System.Collections.Generic;
using System.IO;
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
            catch (Exception ex)
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
                            City = Convert.ToInt64(ddlcity.SelectedValue),
                            CompanyLogo = Image,
                            CompanyName = txtCompanyName.Text,
                            ContactNo1 = Convert.ToDecimal(txtContactNo1.Text),
                            ContactNo2 = Convert.ToDecimal(txtContactNo2.Text),
                            Country = Convert.ToInt64(ddlCountry.SelectedValue),
                            CreateDate = System.DateTime.Now,
                            CUser = 1,
                            EmailId = txtEmail.Text,
                            FaxNo = Convert.ToDecimal(txtFax.Text),
                            FoundedYear = Convert.ToInt64(txtFYear.Text),
                            Founder1 = txtFounder1.Text,
                            PostalCode = txtPostalCode.Text,
                            State = Convert.ToInt64(ddlState.SelectedValue)
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
                            City = Convert.ToInt64(ddlcity.SelectedValue),
                            CompanyName = txtCompanyName.Text,
                            ContactNo1 = Convert.ToDecimal(txtContactNo1.Text),
                            ContactNo2 = Convert.ToDecimal(txtContactNo2.Text),
                            Country = Convert.ToInt64(ddlCountry.SelectedValue),
                            CreateDate = System.DateTime.Now,
                            CUser = 1,
                            EmailId = txtEmail.Text,
                            FaxNo = Convert.ToDecimal(txtFax.Text),
                            FoundedYear = Convert.ToInt64(txtFYear.Text),
                            Founder1 = txtFounder1.Text,
                            PostalCode = txtPostalCode.Text,
                            State = Convert.ToInt64(ddlState.SelectedValue)
                        };
                        db.tbl_CompanyDetails.InsertOnSubmit(company);
                        db.SubmitChanges();
                        BindCompany();
                    }
                }

                if (btnSubmit.Text == "Update")
                {
                    tbl_CompanyDetail company = db.tbl_CompanyDetails.Single(x => x.Id == 1);
                    if (FuImg.HasFile)
                    {
                        string str = FuImg.FileName;
                        File.Delete(Server.MapPath(company.CompanyLogo));
                        FuImg.PostedFile.SaveAs(Server.MapPath("~/company_logo/" + str));
                        string Image = "~/company_logo/" + str.ToString();

                        company.AddressLine1 = txtAdd1.Text;
                        company.AddressLine2 = txtAdd2.Text;
                        company.AddressLine3 = txtAdd3.Text;
                        company.City = Convert.ToInt64(ddlcity.SelectedValue);
                        company.CompanyLogo = Image;
                        company.CompanyName = txtCompanyName.Text;
                        company.ContactNo1 = Convert.ToDecimal(txtContactNo1.Text);
                        company.ContactNo2 = Convert.ToDecimal(txtContactNo2.Text);
                        company.Country = Convert.ToInt64(ddlCountry.SelectedValue);
                        company.UpdateDate = System.DateTime.Now;
                        company.UUser = 1;
                        company.EmailId = txtEmail.Text;
                        company.FaxNo = Convert.ToDecimal(txtFax.Text);
                        company.FoundedYear = Convert.ToInt64(txtFYear.Text);
                        company.Founder1 = txtFounder1.Text;
                        company.PostalCode = txtPostalCode.Text;
                        company.State = Convert.ToInt64(ddlState.SelectedValue);

                        db.SubmitChanges();
                        BindCompany();
                    }
                    else
                    {

                        company.AddressLine1 = txtAdd1.Text;
                        company.AddressLine2 = txtAdd2.Text;
                        company.AddressLine3 = txtAdd3.Text;
                        company.City = Convert.ToInt64(ddlcity.SelectedValue);
                        company.CompanyName = txtCompanyName.Text;
                        company.ContactNo1 = Convert.ToDecimal(txtContactNo1.Text);
                        company.ContactNo2 = Convert.ToDecimal(txtContactNo2.Text);
                        company.Country = Convert.ToInt64(ddlCountry.SelectedValue);
                        company.UpdateDate = System.DateTime.Now;
                        company.UUser = 1;
                        company.EmailId = txtEmail.Text;
                        company.FaxNo = Convert.ToDecimal(txtFax.Text);
                        company.FoundedYear = Convert.ToInt64(txtFYear.Text);
                        company.Founder1 = txtFounder1.Text;
                        company.PostalCode = txtPostalCode.Text;
                        company.State = Convert.ToInt64(ddlState.SelectedValue);

                        db.SubmitChanges();
                        BindCompany();
                    }
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
            tbl_CompanyDetail company = db.tbl_CompanyDetails.Single(x => x.Id == 1);
            if (company != null)
            {
                BindCountries();
                txtAdd1.Text = company.AddressLine1.ToString();
                txtAdd2.Text = company.AddressLine2;
                txtAdd3.Text = company.AddressLine3;
                txtCompanyName.Text = company.CompanyName;
                txtContactNo1.Text = company.ContactNo1.ToString();
                txtContactNo2.Text = company.ContactNo2.ToString();
                txtEmail.Text = company.EmailId.ToString();
                txtFax.Text = company.FaxNo.ToString();
                txtFounder1.Text = company.Founder1;
                txtFYear.Text = company.FoundedYear.ToString();
                txtPostalCode.Text = company.PostalCode.ToString();
                ddlCountry.SelectedValue = company.Country.Value.ToString();
                try
                {
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
                ddlState.SelectedValue = company.State.Value.ToString();
                try
                {
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
                ddlcity.SelectedValue = company.City.Value.ToString();
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