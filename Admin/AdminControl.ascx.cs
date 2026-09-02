using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFSOFTOnline.Admin
{
    public partial class AdminControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) Response.Redirect("Administrator.aspx");
            string s = Request["f"];
            switch(s)
            {
                case "news":
                    plLoad.Controls.Add(LoadControl("News/NewsControl.ascx"));
                    break;
                case "product":
                    plLoad.Controls.Add(LoadControl("Product/ProductControl.ascx"));
                    break;
                case "user":
                    plLoad.Controls.Add(LoadControl("User/UserControl.ascx"));
                    break;
            }
        }

        protected void lnkExit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Administrator.aspx");

        }
    }
}