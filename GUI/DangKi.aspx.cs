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
    public partial class DangKi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Đã đăng nhập => Chuyển về trang chủ
            if (Request.Cookies["TaiKhoan"] != null)
            {
                Response.Redirect("index.aspx");
            }
            lblAnhDaiDienLoiDungLuong.Visible = lblAnhDaiDienLoiFile.Visible = lblDangKiThatBai.Visible = false;
        }

        private void DangKiTaiKhoan(string extension = ".png")
        {
            clsTaiKhoanDTO taiKhoanDTO = new clsTaiKhoanDTO();
            taiKhoanDTO.TenTaiKhoan = txtTenTaiKhoan.Text;
            taiKhoanDTO.MatKhau = txtMatKhau.Text;
            taiKhoanDTO.Email = txtEmail.Text;
            taiKhoanDTO.DiaChi = txtDiaChi.Text;
            taiKhoanDTO.HoTen = txtHoTen.Text;
            taiKhoanDTO.SDT = txtSDT.Text;
            if (filAnhDaiDien.HasFile)
            {
                taiKhoanDTO.AnhDaiDien = txtTenTaiKhoan.Text + extension;
            }
            else
            {
                if (imgAnhDaiDien.ImageUrl != "~/img/AnhDaiDien/profile.png")
                {
                    taiKhoanDTO.AnhDaiDien = txtHoTen.Text + ".jpg";
                }
                else
                {
                    taiKhoanDTO.AnhDaiDien = "profile.png";
                }
            }
            if (clsTaiKhoanBUS.ThemTK(taiKhoanDTO))
            {
                filAnhDaiDien.SaveAs(Server.MapPath("~/img/AnhDaiDien/") + txtTenTaiKhoan.Text + extension);
                HttpCookie cookie = new HttpCookie("TaiKhoan");
                cookie["TenTaiKhoan"] = taiKhoanDTO.TenTaiKhoan;
                cookie["HoTen"] = Server.UrlEncode(taiKhoanDTO.HoTen);
                cookie.Expires = DateTime.Now.AddDays(14);
                Response.Cookies.Add(cookie);
                Response.Redirect("index.aspx");
            }
            else
            {
                lblDangKiThatBai.Visible = true;
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.Text = txtMatKhau.Text = txtNhapLaiMatKhau.Text = txtEmail.Text = txtSDT.Text = txtDiaChi.Text = txtHoTen.Text = string.Empty;
        }

        protected void btnXoaAnhDaiDien_Click(object sender, EventArgs e)
        {
            imgAnhDaiDien.ImageUrl = "~/img/AnhDaiDien/profile.png";
        }

        protected void btnDangKi_Click(object sender, EventArgs e)
        {
            if (filAnhDaiDien.HasFile)
            {
                if (filAnhDaiDien.PostedFile.ContentType == "image/jpeg")
                {
                    if (filAnhDaiDien.PostedFile.ContentLength <= 1 * 1024 * 1024)
                    {
                        DangKiTaiKhoan(".jpg");
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
                            DangKiTaiKhoan(".png");
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
                DangKiTaiKhoan();
            }
        }
    }
}