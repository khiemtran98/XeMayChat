using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DTO;

namespace GUI
{
    public partial class LichSuGiaoDich : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                XoaThongBao();
                if (Request.Cookies["TaiKhoan"] != null)
                {
                    LoadLichSuGiaoDich(Request.Cookies["TaiKhoan"]["TenTaiKhoan"]);
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        private void LoadLichSuGiaoDich(string tenTK)
        {
            grvHoaDon.DataSource = clsHoaDonBUS.LayLichSuGiaoDich(tenTK);
            grvHoaDon.DataBind();
            if (grvHoaDon.Rows.Count == 0)
            {
                lblThongBao.Visible = true;
            }
        }

        private void XoaThongBao()
        {
            lblThongBao.Visible = false;
        }

        protected void grvHoaDon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvHoaDon.PageIndex = e.NewPageIndex;
            LoadLichSuGiaoDich(Request.Cookies["TaiKhoan"]["TenTaiKhoan"]);
        }
    }
}