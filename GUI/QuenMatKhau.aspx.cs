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
    public partial class QuenMatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Đã đăng nhập => Chuyển về trang chủ
            if (Request.Cookies["TaiKhoan"] != null)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnTiepTuc_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTaiKhoan.Text;
            string email = txtEmail.Text;
            string sdt = txtSDT.Text;

            // Email và SĐT đúng => Hiển thị form đổi mật khẩu
            clsTaiKhoanDTO taiKhoanDTO = clsTaiKhoanBUS.LayTK(tenTK);
            if (email == taiKhoanDTO.Email && sdt == taiKhoanDTO.SDT)
            {
                panQuenMatKhau.Visible = false;
                panDoiMatKhau.Visible = true;
            }
            // Email và SĐT không đúng => Hiển thị thông báo lỗi
            else
            {
                lblThongTinSai.Visible = true;
            }
        }

        protected void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string tenTK = txtTenTaiKhoan.Text;
            string mK = txtMatKhauMoi.Text;

            if (clsTaiKhoanBUS.DoiMatKhau(tenTK, mK))
            {
                lblDoiMKThanhCong.Visible = true;
            }
            else
            {
                lblDoiMKThatBai.Visible = true;
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.Text = txtEmail.Text = txtSDT.Text = txtMatKhauMoi.Text = txtNhapLaiMatKhauMoi.Text = string.Empty;
            panQuenMatKhau.Visible = true;
            panDoiMatKhau.Visible = false;
        }
    }
}