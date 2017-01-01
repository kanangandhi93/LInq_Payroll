using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LInq_Payroll
{
    public partial class country : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            try
            {
                DBPayrollDataContext db = new DBPayrollDataContext();
                var rr = from p in db.tbl_Countries
                         select new { p.CountryName, p.Id };
                repData.DataSource = rr;
                repData.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("OOps something went wrong.");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    DBPayrollDataContext db = new DBPayrollDataContext();
                    tbl_Country Country = new tbl_Country();
                    Country.CountryName = txtCountryName.Text;
                    db.tbl_Countries.InsertOnSubmit(Country);
                    db.SubmitChanges();
                }
                if (btnSubmit.Text == "Update")
                {
                    DBPayrollDataContext db = new DBPayrollDataContext();
                    tbl_Country Country = db.tbl_Countries.Single(x => x.Id == Convert.ToInt64(ConfigurationManager.AppSettings["EditId"]));
                    Country.CountryName = txtCountryName.Text;
                    //db.tbl_Countries.InsertOnSubmit(Country);
                    db.SubmitChanges();
                    btnSubmit.Text = "Submit";
                }
                txtCountryName.Text = "";
                BindRepeater();
            }
            catch (Exception ex)
            {
                Response.Write("OOps something went wrong.");
            }
        }

        protected void repData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    DBPayrollDataContext db = new DBPayrollDataContext();
                    var rr = from p in db.tbl_Countries
                             where p.Id == Convert.ToInt64(e.CommandArgument)
                             select new { p.CountryName, p.Id };
                    if (rr.Count() > 0)
                    {
                        txtCountryName.Text = rr.First().CountryName;
                        ConfigurationManager.AppSettings["EditId"] = rr.First().Id.ToString();
                        btnSubmit.Text = "Update";
                    }
                }

                if (e.CommandName == "Delete")
                {
                    DBPayrollDataContext db = new DBPayrollDataContext();
                    tbl_Country Country = db.tbl_Countries.Single(x => x.Id == Convert.ToInt64(e.CommandArgument));
                    db.tbl_Countries.DeleteOnSubmit(Country);
                    db.SubmitChanges();
                    BindRepeater();
                }
            }
            catch (Exception ex)
            {
                Response.Write("OOps something went wrong.");
            }
        }
    }
}