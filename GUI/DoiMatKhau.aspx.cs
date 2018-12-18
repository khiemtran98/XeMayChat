using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;

namespace GUI
{
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Chưa đăng nhập => Chuyển về trang index
            if (Request.Cookies["TaiKhoan"] == null)
            {
                Response.Redirect("index.aspx");
            }
            // Đã đăng nhập => Ẩn tất cả Label thông báo, tùy trường hợp sẽ hiện thông báo tương ứng
            else
            {
                lblDoiMKThanhCong.Visible = lblDoiMKThatBai.Visible = lblMKCuSai.Visible = false;
            }
        }

        protected void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string tenTK = Request.Cookies["TaiKhoan"]["TenTaiKhoan"].ToString();
            string mKCu = txtMatKhauCu.Text;
            string mKMoi = txtMatKhauMoi.Text;

            // Mật khẩu cũ đúng
            if (mKCu == clsTaiKhoanBUS.LayMatKhau(tenTK))
            {
                // Đổi mật khẩu thành công
                if (clsTaiKhoanBUS.DoiMatKhau(tenTK, mKMoi))
                {
                    lblDoiMKThanhCong.Visible = true;
                }
                // Đổi mật khẩu thất bại
                else
                {
                    lblDoiMKThatBai.Visible = true;
                }
            }
            // Mật khẩu cũ sai
            else
            {
                lblMKCuSai.Visible = true;
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Text = txtMatKhauMoi.Text = txtNhapLaiMatKhauMoi.Text = string.Empty;
        }
    }
}