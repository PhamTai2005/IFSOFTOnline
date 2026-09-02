using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;
namespace IFSOFTOnline.Admin.News
{
    public partial class NewCategory : System.Web.UI.UserControl
    {
        clsNews _news = new clsNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            rptNewsCategory.DataSource = _news.GetList();
            rptNewsCategory.DataBind();

        }

        protected void lnkAddNew_Click(object sender, EventArgs e)
        {
            hdInsert.Value = "Insert";
            mul.ActiveViewIndex = 1;
        }

        protected void msgDel(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete selected Category?')";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdInsert.Value == "Insert")
            {
                if (!string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
                {
                    bool active = chkActive.Checked ? true : false;
                    _news.Insert(txtCategoryName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else //upade
            {
                if (!string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
                {
                    bool active = chkActive.Checked ? true : false;
                    _news.Update(int.Parse(hdCategoryID.Value), txtCategoryName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                    Response.Redirect(Request.Url.ToString());
                }
            }
        }

        protected void rptNewsCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            switch(e.CommandName.ToString())
            {
                case "update":
                    dt =_news.GetListbyCategoryID(int.Parse(e.CommandArgument.ToString()));

                    if(dt.Rows.Count > 0)
                    {
                        txtCategoryName.Text = dt.Rows[0]["CategoryName"].ToString();
                        txtOrder.Text = dt.Rows[0]["Order"].ToString();
                        // Thay dòng cũ bằng dòng này:
                        // Thay vì so sánh với "1", hãy thử so sánh với giá trị thực tế của nó:
                        chkActive.Checked = dt.Rows[0]["Active"].ToString().Equals("True") ? true : false;
                        hdCategoryID.Value = e.CommandArgument.ToString();
                        hdInsert.Value = "update";
                        mul.ActiveViewIndex = 1;
                    }
                    break;
                    case "delete":
                    dt = _news.GetListbyCategoryID(int.Parse(e.CommandArgument.ToString()));
                    if(dt.Rows.Count >0)
                    {
                        // Thao tác xóa;
                        _news.Delete(int.Parse(e.CommandArgument.ToString()));
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }
    }
}