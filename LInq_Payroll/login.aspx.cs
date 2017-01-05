using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using enc_dec;

namespace LInq_Payroll
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DBPayrollDataContext db = new DBPayrollDataContext();
                tbl_Emp_P_Detail login = db.tbl_Emp_P_Details.Single(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Text);
                tbl_Role role = db.tbl_Roles.Single(x => x.Id == login.RoleId);
                if (login != null)
                {
                    Class1 enc = new Class1();
                    Session["Login"] = enc.EncryptId(login.EmpId.ToString());
                    Session["RoleId"] = enc.EncryptId(role.RoleName);
                    Response.Redirect("default.aspx");
                }
                else
                {
                    lblMessage.Text = "Login Failed";
                    // Response.Write("<script>alert('Login Failed. Please Try again')</script>");
                    // Response.Redirect("login.aspx");
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Login Failed";
                // Response.Write("<script>alert('Login Failed. Please Try again')</script>");
                // Response.Redirect("login.aspx");
            }
        }
    }
}