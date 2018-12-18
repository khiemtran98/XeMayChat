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
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dtlMenuLoaiSP.DataSource = clsLoaiSPBUS.LayDSLoaiSP();
            dtlMenuLoaiSP.DataBind();

            // Đã đăng nhập
            if (Request.Cookies["TaiKhoan"] != null)
            {
                clsTaiKhoanDTO TK = clsTaiKhoanBUS.LayTK(Request.Cookies["TaiKhoan"]["TenTaiKhoan"]);
                if (TK.LaAdmin)
                {
                    navAdminCP.Visible = true;
                }
                else
                {
                    navAdminCP.Visible = false;
                }
                HttpCookie cookie = Request.Cookies["TaiKhoan"];
                lblTenTaiKhoan.Text = Server.UrlDecode(cookie["HoTen"]);
                HienThiGiaoDien(true);
                lblSoLuongGioHang.Text = clsGioHangBUS.DemSoLuongSanPhamTrongGH(Request.Cookies["TaiKhoan"]["TenTaiKhoan"].ToString()).ToString();
            }
            // Chưa đăng nhập
            else
            {
                HienThiGiaoDien(false);
                navAdminCP.Visible = false;
            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTaiKhoan.Text;
            string mK = txtMatKhau.Text;

            if (clsTaiKhoanBUS.KiemTraDangNhap(tenTK, mK))
            {
                HttpCookie cookie = new HttpCookie("TaiKhoan");
                cookie["TenTaiKhoan"] = tenTK;
                cookie["HoTen"] = Server.UrlEncode(clsTaiKhoanBUS.LayHoTen(tenTK));
                cookie.Expires = DateTime.Now.AddDays(14);
                Response.Cookies.Add(cookie);
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                lblLoiDangNhap.Visible = true;
            }
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["TaiKhoan"] != null)
            {
                HttpCookie cookie = new HttpCookie("TaiKhoan");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                Response.Redirect(Request.RawUrl);
            }
        }

        private void HienThiGiaoDien(bool trangThaiDangNhap)
        {
            navDangKi.Visible = !trangThaiDangNhap;
            navDangNhap.Visible = !trangThaiDangNhap;
            navTaiKhoan.Visible = trangThaiDangNhap;
            navGioHang.Visible = trangThaiDangNhap;
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != string.Empty)
            {
                Response.Redirect("index.aspx?TimKiem=" + txtTimKiem.Text);
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}