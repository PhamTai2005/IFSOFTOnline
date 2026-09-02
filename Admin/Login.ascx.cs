using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;
namespace IFSOFTOnline.Admin
{
    public partial class Login : System.Web.UI.UserControl
    {
        clsAdminUser _admin = new clsAdminUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()) && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                DataTable dt = new DataTable();
                dt = _admin.Login(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    Session["username"] = txtUserName.Text.Trim();
                    Response.Redirect("Administrator.aspx");
                }
                else
                {
                    Response.Write("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
        }
    }
}