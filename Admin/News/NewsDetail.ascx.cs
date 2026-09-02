using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;

namespace IFSOFTOnline.Admin.News
{
    public partial class NewsDetailControl : System.Web.UI.UserControl
    {
         
        protected global::System.Web.UI.WebControls.FileUpload FileUpload;
        clsNews _news = new clsNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                
                LoadDataDropDownlist();
                LoadDataDropDownlist1();
                LoadNewsDetail();
            }
        }

        void LoadDataDropDownlist()
        {
            drpNewsCategory.DataSource = _news.GetList();
            drpNewsCategory.DataValueField = "CategoryID";
            drpNewsCategory.DataTextField = "CategoryName";
            drpNewsCategory.DataBind();
        }

        void LoadDataDropDownlist1()
        {
            drpNewsCategory1.DataSource = _news.GetList();
            drpNewsCategory1.DataValueField = "CategoryID";
            drpNewsCategory1.DataTextField = "CategoryName";
            drpNewsCategory1.DataBind();
        }
        void LoadNewsDetail()
        {
            rptNewsDetails.DataSource = _news.GetListNewsDetail(int.Parse(drpNewsCategory1.SelectedValue.ToString()));
            rptNewsDetails.DataBind();
        }


        protected void btntest_Click(object sender, EventArgs e)
        {
            Response.Write(txtContent.Text);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Upload image
            // 1. Xử lý Upload Ảnh
            string typefile = "";
            string file = hdImage.Value;
           
            string originalFileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
            if (FileUpload.FileName.Length > 0)
            {
                // Kiểm tra dung lượng file < 5MB (5000000 bytes)
                if (FileUpload.PostedFile.ContentLength < 5000000)
                {
                    // Kiểm tra định dạng ảnh là jpeg hoặc png
                    if (FileUpload.PostedFile.ContentType.Equals("image/jpeg") || FileUpload.PostedFile.ContentType.Equals("image/png"))
                    {
                        typefile = System.IO.Path.GetExtension(FileUpload.FileName).ToLower();
                        file = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);

                        // Đổi tên file để tránh trùng lặp bằng cách thêm thời gian hiện tại
                        file = FileUpload.FileName.Replace(originalFileName, "IFSOFT" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + typefile);

                        // Lưu file vào thư mục gốc của web
                        FileUpload.PostedFile.SaveAs(Server.MapPath("~/Image/") + file);
                    }
                }
            }
            //Kiem tra Image da ton tai
            if(!file.Equals(hdImage.Value))
            {
                if (!hdImage.Value.Equals(""))
                {
                    if(System.IO.File.Exists(Server.MapPath("~/Image/" + hdImage.Value)) == true )
                    {
                        System.IO.File.Exists(Server.MapPath("~/Image/" + hdImage.Value));
                    }
                }
            }
            // Them moi Data
            if(!string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                if(hdInsert.Value=="insert")
                {
                    bool active = chkActive.Checked ? true : false;
                    _news.InsertDetail(int.Parse(drpNewsCategory.SelectedValue.ToString()), txtTitle.Text.Trim(), txtDesc.Text.Trim(), txtContent.Text.Trim(), file, DateTime.Now, txtAuthor.Text.Trim(), active);
                    Response.Redirect(Request.Url.ToString());
                }
                else
                {
                    //cap nhat
                    bool active = chkActive.Checked ? true : false;
                    _news.UpdateDetail(int.Parse(hdNewsDetailID.Value.ToString()),int.Parse(drpNewsCategory.SelectedValue.ToString()), txtTitle.Text.Trim(), txtDesc.Text.Trim(), txtContent.Text.Trim(), file, txtAuthor.Text.Trim(), active);
                    Response.Redirect(Request.Url.ToString());
                }
                Response.Redirect(Request.Url.ToString());

            }        
        }

        protected void lnkUpdate_Click1(object sender, EventArgs e)
        {
            hdInsert.Value = "insert";
            mul.ActiveViewIndex = 1;

        }

        protected void rptNewsDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _news.GetListNewsDetails_by_NewsDetailID(int.Parse(e.CommandArgument.ToString()));
            switch (e.CommandName.ToString())
            {
                case "update":
                    if (dt.Rows.Count > 0)
                    {
                        drpNewsCategory.SelectedValue = dt.Rows[0]["CategoryID"].ToString();
                        txtTitle.Text = dt.Rows[0]["vTitle"].ToString();
                        txtDesc.Text = dt.Rows[0]["vDesc"].ToString();
                        txtContent.Text = dt.Rows[0]["vContent"].ToString();
                        txtAuthor.Text= dt.Rows[0]["vAuthor"].ToString();
                        hdNewsDetailID.Value = e.CommandArgument.ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["Active"]) ? true : false;
                        hdImage.Value = dt.Rows[0]["vImage"].ToString();
                        hdInsert.Value = "update";

                        mul.ActiveViewIndex = 1;
                    }
                    break;
                case "delete":
                    if (dt.Rows.Count > 0)
                    {
                        //Xoa hinh trong thu muc
                        if (System.IO.File.Exists(Server.MapPath("~/Image/" + dt.Rows[0]["vImage"])) == true)
                        {
                            System.IO.File.Delete(Server.MapPath("~/Image/" + dt.Rows[0]["vImage"]));   // <-- XÓA thật
                        }
                        // Xoa du lieu trong SQL Server
                        _news.DeleteDetail(int.Parse(e.CommandArgument.ToString()));
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }
        protected void msgDel(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete selected News_Detail?')";
        }

        protected void drpNewsCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNewsDetail();
        }
    }
}