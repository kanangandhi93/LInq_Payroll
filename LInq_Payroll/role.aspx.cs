using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LInq_Payroll
{
    public partial class role : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindRepeater();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops Soomething went wrong.')</script>");
            }
        }
        private void BindRepeater()
        {
            try
            {
                DBPayrollDataContext db = new DBPayrollDataContext();
                var rr = from p in db.tbl_Roles
                         select new { p.RoleName, p.Id };
                repData.DataSource = rr;
                repData.DataBind();
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
                if (btnSubmit.Text == "Submit")
                {
                    DBPayrollDataContext db = new DBPayrollDataContext();
                   tbl_Role role= new tbl_Role();
                    role.RoleName = txtCountryName.Text;
                    db.tbl_Roles.InsertOnSubmit(role);
                    db.SubmitChanges();
                }
                if (btnSubmit.Text == "Update")
                {
                    DBPayrollDataContext db = new DBPayrollDataContext();
                    tbl_Role role = db.tbl_Roles.Single(x => x.Id == Convert.ToInt64(ConfigurationManager.AppSettings["EditId"]));
                    role.RoleName = txtCountryName.Text;
                    //db.tbl_Countries.InsertOnSubmit(Country);
                    db.SubmitChanges();
                    btnSubmit.Text = "Submit";
                }
                txtCountryName.Text = "";
                BindRepeater();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops Soomething went wrong.')</script>");
            }
        }

        protected void repData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    DBPayrollDataContext db = new DBPayrollDataContext();
                    var rr = from p in db.tbl_Roles
                             where p.Id == Convert.ToInt64(e.CommandArgument)
                             select new { p.RoleName, p.Id };
                    if (rr.Count() > 0)
                    {
                        txtCountryName.Text = rr.First().RoleName;
                        ConfigurationManager.AppSettings["EditId"] = rr.First().Id.ToString();
                        btnSubmit.Text = "Update";
                    }
                }

                if (e.CommandName == "Delete")
                {
                    DBPayrollDataContext db = new DBPayrollDataContext();
                    tbl_Role Role = db.tbl_Roles.Single(x => x.Id == Convert.ToInt64(e.CommandArgument));
                    db.tbl_Roles.DeleteOnSubmit(Role);
                    db.SubmitChanges();
                    BindRepeater();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Oops Soomething went wrong.')</script>");
            }
        }
    }
}