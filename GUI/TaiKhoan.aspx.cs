using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DTO;

namespace GUI
{
    public partial class TaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Đã đăng nhập => Load thông tin tài khoản. Ẩn tất cả Label thông báo, tùy trường hợp sẽ hiện thông báo tương ứng
            if (Request.Cookies["TaiKhoan"] != null)
            {
                if (!Page.IsPostBack)
                {
                    LoadThongTinTaiKhoan();
                }
                lblCapNhatThanhCong.Visible = lblCapNhatThatBai.Visible = lblAnhDaiDienLoiDungLuong.Visible = lblAnhDaiDienLoiFile.Visible = false;
            }
            // Chưa đăng nhập => Chuyển về trang chủ
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        private void UpAnhDaiDien(string extension)
        {
            string filename = Path.GetFileName(filAnhDaiDien.FileName);
            filAnhDaiDien.SaveAs(Server.MapPath("~/img/AnhDaiDien/") + txtTenTaiKhoan.Text + extension);
        }

        private void CapNhatTaiKhoan(string extension = ".png")
        {
            // Tạo 1 đối tượng clsTaiKhoanDTO chứa thông tin hiện tại của tài khoản
            string tenTK = Request.Cookies["TaiKhoan"]["TenTaiKhoan"].ToString();
            clsTaiKhoanDTO taiKhoanDTO = clsTaiKhoanBUS.LayTK(tenTK);

            // Cập nhật thông tin của đối tượng clsTaiKhoanDTO theo dữ liệu người dùng nhập
            taiKhoanDTO.Email = txtEmail.Text;
            taiKhoanDTO.SDT = txtSDT.Text;
            taiKhoanDTO.DiaChi = txtDiaChi.Text;
            taiKhoanDTO.HoTen = txtHoTen.Text;
            if (filAnhDaiDien.HasFile)
            {
                taiKhoanDTO.AnhDaiDien = /*"~/img/AnhDaiDien/" +*/ txtTenTaiKhoan.Text + extension;
            }
            else
            {
                if (imgAnhDaiDien.ImageUrl != "~/img/AnhDaiDien/profile.png")
                {
                    taiKhoanDTO.AnhDaiDien = txtHoTen.Text + extension;
                }
                else
                {
                    taiKhoanDTO.AnhDaiDien = "profile.png";
                }
            }

            // Cập nhật thành công
            if (clsTaiKhoanBUS.SuaTK(taiKhoanDTO))
            {
                if (filAnhDaiDien.HasFile)
                {
                    UpAnhDaiDien(extension);
                }
                lblCapNhatThanhCong.Visible = true;
                LoadThongTinTaiKhoan();
                
                HttpCookie cookie = new HttpCookie("TaiKhoan");
                cookie["TenTaiKhoan"] = txtTenTaiKhoan.Text;
                cookie["HoTen"] = Server.UrlEncode(txtHoTen.Text);
                cookie.Expires = DateTime.Now.AddDays(14);
                Response.Cookies.Add(cookie);

                Label TenTK = (Label)Master.FindControl("lblTenTaiKhoan");
                TenTK.Text = Server.UrlDecode(txtHoTen.Text);
            }
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (filAnhDaiDien.HasFile)
            {
                if (filAnhDaiDien.PostedFile.ContentType == "image/jpeg")
                {
                    if (filAnhDaiDien.PostedFile.ContentLength <= 1 * 1024 * 1024)
                    {
                        CapNhatTaiKhoan(".jpg");
                    }
                    else
                    {
                        lblAnhDaiDienLoiDungLuong.Visible = true;
                    }
                }
                else
                {
                    if (filAnhDaiDien.PostedFile.ContentType == "image/png")
                    {
                        if (filAnhDaiDien.PostedFile.ContentLength <= 1 * 1024 * 1024)
                        {
                            CapNhatTaiKhoan(".png");
                        }
                        else
                        {
                            lblAnhDaiDienLoiDungLuong.Visible = true;
                        }
                    }
                    else
                    {
                        lblAnhDaiDienLoiFile.Visible = true;
                    }
                }
            }
            else
            {
                CapNhatTaiKhoan();
            }
        }

        // Nhấn nút Hủy => Load lại thông tin của tài khoản
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            LoadThongTinTaiKhoan();
        }

        private void LoadThongTinTaiKhoan()
        {
            string tenTK = Request.Cookies["TaiKhoan"]["TenTaiKhoan"].ToString();
            clsTaiKhoanDTO taiKhoanDTO = clsTaiKhoanBUS.LayTK(tenTK);

            txtTenTaiKhoan.Text = taiKhoanDTO.TenTaiKhoan;
            txtEmail.Text = taiKhoanDTO.Email;
            txtSDT.Text = taiKhoanDTO.SDT;
            txtDiaChi.Text = taiKhoanDTO.DiaChi;
            txtHoTen.Text = taiKhoanDTO.HoTen;
            imgAnhDaiDien.ImageUrl = "~/img/AnhDaiDien/" + taiKhoanDTO.AnhDaiDien;
        }

        protected void btnXoaAnhDaiDien_Click(object sender, EventArgs e)
        {
            imgAnhDaiDien.ImageUrl = "~/img/AnhDaiDien/profile.png";
        }
    }
}