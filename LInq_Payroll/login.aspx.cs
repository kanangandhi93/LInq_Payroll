using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LInq_Payroll
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DBPayrollDataContext db = new DBPayrollDataContext();
            tbl_Emp_P_Detail login = db.tbl_Emp_P_Details.Single(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Text);
            if (login != null)
            {
                Session["Login"] = login.EmpId;
            }
        }
    }
}