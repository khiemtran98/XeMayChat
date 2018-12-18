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
    public partial class QLSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDuLieuLoaiSanPham();
                LoadDuLieuSanPham();
            }
            XoaThongBao();
        }

        private void ThemSanPham(string extension = ".png")
        {
            clsSanPhamDTO SanPham = new clsSanPhamDTO();
            SanPham.MaSP = txtMaSP.Text;
            SanPham.TenSP = txtTenSP.Text;
            SanPham.ThongTin = txtThongTin.Text;
            SanPham.GiaTien = int.Parse(txtGiaTien.Text);
            SanPham.SoLuongTonKho = int.Parse(txtSoLuongTonKho.Text);
            SanPham.MaLoaiSP = ddlMaLoaiSP.SelectedValue;
            if (filAnhMinhHoa.HasFile)
            {
                SanPham.AnhMinhHoa = txtMaSP.Text + extension;
            }
            SanPham.TrangThai = chkTrangThai.Checked;
            if (clsSanPhamBUS.ThemSanPham(SanPham))
            {
                if (filAnhMinhHoa.HasFile)
                {
                    filAnhMinhHoa.SaveAs(Server.MapPath("~/img/AnhMinhHoa/") + txtMaSP.Text + extension);
                }
                LoadDuLieuSanPham();
                lblThemThanhCong.Visible = true;
                XoaForm();
            }
            else
            {
                lblThemThatBaiMaSP.Visible = true;
            }
        }

        private void SuaSanPham(string extension = ".png")
        {
            clsSanPhamDTO SanPham = new clsSanPhamDTO();
            SanPham.MaSP = txtMaSP.Text;
            SanPham.TenSP = txtTenSP.Text;
            SanPham.ThongTin = txtThongTin.Text;
            SanPham.GiaTien = int.Parse(txtGiaTien.Text);
            SanPham.SoLuongTonKho = int.Parse(txtSoLuongTonKho.Text);
            SanPham.MaLoaiSP = ddlMaLoaiSP.SelectedValue;
            if (filAnhMinhHoa.HasFile)
            {
                SanPham.AnhMinhHoa = txtMaSP.Text + extension;
            }
            else
            {
                if (imgAnhMinhHoa.ImageUrl != "~/img/AnhMinhHoa/product.png")
                {
                    SanPham.AnhMinhHoa = txtMaSP.Text + ".jpg";
                }
            }
            SanPham.TrangThai = chkTrangThai.Checked;
            if (clsSanPhamBUS.SuaSanPham(SanPham))
            {
                if (filAnhMinhHoa.HasFile)
                {
                    filAnhMinhHoa.SaveAs(Server.MapPath("~/img/AnhMinhHoa/") + txtMaSP.Text + extension);
                }
                LoadDuLieuSanPham();
                lblSuaThanhCong.Visible = true;
                XoaForm();
            }
        }

        private void LoadDuLieuSanPham()
        {
            grvSanPham.DataSource = clsSanPhamBUS.LayDSSanPham_AdminCP();
            grvSanPham.DataBind();
            CheDoSua(false);
            XoaForm();
            XoaThongBao();
        }

        private void LoadDuLieuLoaiSanPham()
        {
            ddlMaLoaiSP.DataSource = clsLoaiSPBUS.LayDSLoaiSP_AdminCP();
            ddlMaLoaiSP.DataTextField = "TenLoaiSP";
            ddlMaLoaiSP.DataValueField = "MaLoaiSP";
            ddlMaLoaiSP.DataBind();
            ListItem blank = new ListItem();
            blank.Text = "(Chọn hãng sản xuất)";
            blank.Value = "blank";
            ddlMaLoaiSP.Items.Insert(0, blank);
            
            ddlPhanLoaiSP.DataSource = clsLoaiSPBUS.LayDSLoaiSP_AdminCP();
            ddlPhanLoaiSP.DataTextField = "TenLoaiSP";
            ddlPhanLoaiSP.DataValueField = "MaLoaiSP";
            ddlPhanLoaiSP.DataBind();
            ddlPhanLoaiSP.Items.Insert(0, blank);
        }

        private void XoaThongBao()
        {
            lblAnhMinhHoaLoiDungLuong.Visible = false;
            lblAnhMinhHoaLoiFile.Visible = false;
            lblThemThanhCong.Visible = false;
            lblThemThatBaiMaSP.Visible = false;
            lblThemThatBaiMaLoaiSP.Visible = false;
            lblXoaThanhCong.Visible = false;
            lblSuaThanhCong.Visible = false;
            lblSuaThatBai.Visible = false;
        }

        private void XoaForm()
        {
            txtMaSP.Text = txtTenSP.Text = txtThongTin.Text = txtGiaTien.Text = txtSoLuongTonKho.Text = string.Empty;
            ddlMaLoaiSP.SelectedValue = "blank";
            chkTrangThai.Checked = false;
        }

        private void CheDoSua(bool status)
        {
            txtMaSP.Enabled = !status;
        }

        protected void btnXoaAnhMinhHoa_Click(object sender, EventArgs e)
        {
            imgAnhMinhHoa.ImageUrl = "~/img/AnhMinhHoa/product.png";
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (ddlMaLoaiSP.SelectedValue == "blank")
            {
                lblThemThatBaiMaLoaiSP.Visible = true;
            }
            else
            {
                if (filAnhMinhHoa.HasFile)
                {
                    if (filAnhMinhHoa.PostedFile.ContentType == "image/jpeg")
                    {
                        if (filAnhMinhHoa.PostedFile.ContentLength <= 1 * 1024 * 1024)
                        {
                            ThemSanPham(".jpg");
                        }
                        else
                        {
                            lblAnhMinhHoaLoiDungLuong.Visible = true;
                        }
                    }
                    else
                    {
                        if (filAnhMinhHoa.PostedFile.ContentType == "image/png")
                        {
                            if (filAnhMinhHoa.PostedFile.ContentLength <= 1 * 1024 * 1024)
                            {
                                ThemSanPham(".png");
                            }
                            else
                            {
                                lblAnhMinhHoaLoiDungLuong.Visible = true;
                            }
                        }
                        else
                        {
                            lblAnhMinhHoaLoiFile.Visible = true;
                        }
                    }
                }
                else
                {
                    ThemSanPham();
                }
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (ddlMaLoaiSP.SelectedValue == "blank")
            {
                lblSuaThatBai.Visible = true;
            }
            else
            {
                if (filAnhMinhHoa.HasFile)
                {
                    if (filAnhMinhHoa.PostedFile.ContentType == "image/jpeg")
                    {
                        if (filAnhMinhHoa.PostedFile.ContentLength <= 1 * 1024 * 1024)
                        {
                            SuaSanPham(".jpg");
                        }
                        else
                        {
                            lblAnhMinhHoaLoiDungLuong.Visible = true;
                        }
                    }
                    else
                    {
                        if (filAnhMinhHoa.PostedFile.ContentType == "image/png")
                        {
                            if (filAnhMinhHoa.PostedFile.ContentLength <= 1 * 1024 * 1024)
                            {
                                SuaSanPham(".png");
                            }
                            else
                            {
                                lblAnhMinhHoaLoiDungLuong.Visible = true;
                            }
                        }
                        else
                        {
                            lblAnhMinhHoaLoiFile.Visible = true;
                        }
                    }
                }
                else
                {
                    SuaSanPham();
                }
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            XoaForm();
            CheDoSua(false);
            imgAnhMinhHoa.ImageUrl = "~/img/AnhMinhHoa/product.png";
        }

        protected void grvSanPham_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Chon")
            {
                clsSanPhamDTO SanPham = clsSanPhamBUS.LayThongTinSP(e.CommandArgument.ToString());
                txtMaSP.Text = SanPham.MaSP;
                txtTenSP.Text = SanPham.TenSP;
                txtThongTin.Text = SanPham.ThongTin;
                txtGiaTien.Text = SanPham.GiaTien.ToString();
                txtSoLuongTonKho.Text = SanPham.SoLuongTonKho.ToString();
                ddlMaLoaiSP.SelectedValue = SanPham.MaLoaiSP;
                imgAnhMinhHoa.ImageUrl = "~/img/AnhMinhHoa/" + SanPham.AnhMinhHoa;
                chkTrangThai.Checked = SanPham.TrangThai;
                CheDoSua(true);
            }
            if (e.CommandName == "Xoa")
            {
                clsSanPhamBUS.XoaSanPham(e.CommandArgument.ToString());
                LoadDuLieuSanPham();
                lblXoaThanhCong.Visible = true;
            }
        }

        protected void ddlPhanLoaiSP_TextChanged(object sender, EventArgs e)
        {
            string maLoaiSP = ddlPhanLoaiSP.SelectedValue;
            grvSanPham.DataSource = clsSanPhamBUS.LayDSSanPhamTheoLoai_AdminCP(maLoaiSP);
            grvSanPham.DataBind();
            CheDoSua(false);
            XoaForm();
            XoaThongBao();
        }

        protected void grvSanPham_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSanPham.PageIndex = e.NewPageIndex;
            LoadDuLieuSanPham();
        }
    }
}