using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DTO;

namespace GUI.AdminCP
{
    public partial class QLTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDuLieuTaiKhoan();
            }
            XoaThongBao();
        }

        private void ThemTaiKhoan(string extension = ".png")
        {
            clsTaiKhoanDTO TaiKhoan = new clsTaiKhoanDTO();
            TaiKhoan.TenTaiKhoan = txtTenTaiKhoan.Text;
            TaiKhoan.MatKhau = txtMatKhau.Text;
            TaiKhoan.Email = txtEmail.Text;
            TaiKhoan.DiaChi = txtDiaChi.Text;
            TaiKhoan.HoTen = txtHoTen.Text;
            TaiKhoan.SDT = txtSDT.Text;
            TaiKhoan.LaAdmin = chkLaAdmin.Checked;
            TaiKhoan.TrangThai = chkTrangThai.Checked;
            if (filAnhDaiDien.HasFile)
            {
                TaiKhoan.AnhDaiDien = txtTenTaiKhoan.Text + extension;
            }
            if (clsTaiKhoanBUS.ThemTK(TaiKhoan))
            {
                if (filAnhDaiDien.HasFile)
                {
                    filAnhDaiDien.SaveAs(Server.MapPath("~/img/AnhDaiDien/") + txtTenTaiKhoan.Text + extension);
                }
                LoadDuLieuTaiKhoan();
                lblThemThanhCong.Visible = true;
                XoaForm();
            }
            else
            {
                lblThemThatBai.Visible = true;
            }
        }

        private void SuaTaiKhoan(string extension = ".png")
        {
            clsTaiKhoanDTO TaiKhoan = new clsTaiKhoanDTO();
            TaiKhoan.TenTaiKhoan = txtTenTaiKhoan.Text;
            TaiKhoan.MatKhau = txtMatKhau.Text;
            TaiKhoan.Email = txtEmail.Text;
            TaiKhoan.DiaChi = txtDiaChi.Text;
            TaiKhoan.HoTen = txtHoTen.Text;
            TaiKhoan.SDT = txtSDT.Text;
            TaiKhoan.LaAdmin = chkLaAdmin.Checked;
            TaiKhoan.TrangThai = chkTrangThai.Checked;
            if (filAnhDaiDien.HasFile)
            {
                TaiKhoan.AnhDaiDien = txtTenTaiKhoan.Text + extension;
            }
            else
            {
                if (imgAnhDaiDien.ImageUrl != "~/img/AnhDaiDien/profile.png")
                {
                    TaiKhoan.AnhDaiDien = txtTenTaiKhoan.Text + ".jpg";
                }
            }
            if (clsTaiKhoanBUS.SuaTK(TaiKhoan))
            {
                if (filAnhDaiDien.HasFile)
                {
                    filAnhDaiDien.SaveAs(Server.MapPath("~/img/AnhDaiDien/") + txtTenTaiKhoan.Text + extension);
                }
                LoadDuLieuTaiKhoan();
                lblSuaThanhCong.Visible = true;
                XoaForm();
            }
        }

        private void LoadDuLieuTaiKhoan()
        {
            grvTaiKhoan.DataSource = clsTaiKhoanBUS.LayDSTaiKhoan();
            grvTaiKhoan.DataBind();
            CheDoSua(false);
            XoaForm();
            XoaThongBao();
        }

        private void XoaThongBao()
        {
            lblAnhDaiDienLoiDungLuong.Visible = false;
            lblAnhDaiDienLoiFile.Visible = false;
            lblThemThanhCong.Visible = false;
            lblThemThatBai.Visible = false;
            lblXoaThanhCong.Visible = false;
            lblSuaThanhCong.Visible = false;
        }

        private void XoaForm()
        {
            txtTenTaiKhoan.Text = txtMatKhau.Text = txtEmail.Text = txtSDT.Text = txtDiaChi.Text = txtHoTen.Text = string.Empty;
            chkLaAdmin.Checked = chkTrangThai.Checked = false;
        }

        private void CheDoSua(bool status)
        {
            txtTenTaiKhoan.Enabled = !status;
        }

        protected void btnXoaAnhDaiDien_Click(object sender, EventArgs e)
        {
            imgAnhDaiDien.ImageUrl = "~/img/AnhDaiDien/profile.png";
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (filAnhDaiDien.HasFile)
            {
                if (filAnhDaiDien.PostedFile.ContentType == "image/jpeg")
                {
                    if (filAnhDaiDien.PostedFile.ContentLength <= 1 * 1024 * 1024)
                    {
                        ThemTaiKhoan(".jpg");
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
                            ThemTaiKhoan(".png");
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
                ThemTaiKhoan();
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (filAnhDaiDien.HasFile)
            {
                if (filAnhDaiDien.PostedFile.ContentType == "image/jpeg")
                {
                    if (filAnhDaiDien.PostedFile.ContentLength <= 1 * 1024 * 1024)
                    {
                        SuaTaiKhoan(".jpg");
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
                            SuaTaiKhoan(".png");
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
                SuaTaiKhoan();
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            XoaForm();
            CheDoSua(false);
            imgAnhDaiDien.ImageUrl = "~/img/AnhDaiDien/profile.png";
        }

        protected void grvTaiKhoan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Chon")
            {
                clsTaiKhoanDTO TaiKhoan = clsTaiKhoanBUS.LayTK(e.CommandArgument.ToString());
                txtTenTaiKhoan.Text = TaiKhoan.TenTaiKhoan;
                txtMatKhau.Text = TaiKhoan.MatKhau;
                txtEmail.Text = TaiKhoan.Email;
                txtSDT.Text = TaiKhoan.SDT;
                txtDiaChi.Text = TaiKhoan.DiaChi;
                txtHoTen.Text = TaiKhoan.HoTen;
                chkLaAdmin.Checked = TaiKhoan.LaAdmin;
                imgAnhDaiDien.ImageUrl = "~/img/AnhDaiDien/" + TaiKhoan.AnhDaiDien;
                chkTrangThai.Checked = TaiKhoan.TrangThai;
                CheDoSua(true);
            }
            if (e.CommandName == "Xoa")
            {
                clsTaiKhoanBUS.XoaTK(e.CommandArgument.ToString());
                LoadDuLieuTaiKhoan();
                lblXoaThanhCong.Visible = true;
            }
        }

        protected void grvTaiKhoan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTaiKhoan.PageIndex = e.NewPageIndex;
            LoadDuLieuTaiKhoan();
        }
    }
}