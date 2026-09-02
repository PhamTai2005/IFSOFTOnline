using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFSOFTOnline
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                phAdmin.Controls.Add(LoadControl("~/admin/AdminControl.ascx"));
            }
            else
            {
                phAdmin.Controls.Add(LoadControl("~/admin/Login.ascx"));
            }
            
            Form.Action = Request.Url.PathAndQuery;

        }
    }
}