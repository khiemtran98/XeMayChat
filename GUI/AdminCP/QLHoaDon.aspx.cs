using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DTO;

namespace GUI.AdminCP
{
    public partial class QLHoaDon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDuLieuHoaDon();
                CheDoSuaHD(false);
            }
            XoaThongBao();
            frmCTHD.Visible = false;
        }

        protected void grvHoaDon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonHD")
            {
                clsHoaDonDTO HoaDon = clsHoaDonBUS.LayThongTinHD(e.CommandArgument.ToString());
                txtMaHD.Text = HoaDon.MaHD;
                txtTenTaiKhoan.Text = HoaDon.TenTaiKhoan;
                txtNgayMua.Text = HoaDon.NgayMua.ToString();
                txtDiaChiGiaoHang.Text = HoaDon.DiaChiGiaoHang;
                txtSDTGiaoHang.Text = HoaDon.SDTGiaoHang;
                txtTongTien.Text = HoaDon.TongTien.ToString();

                CheDoSuaHD(true);
                frmCTHD.Visible = true;
                LoadDuLieuCTHoaDon(e.CommandArgument.ToString());
            }
            if (e.CommandName == "XoaHD")
            {
                clsHoaDonDTO hoaDon = new clsHoaDonDTO();
                hoaDon.MaHD = txtMaHD.Text;
                hoaDon.TrangThai = false;
                if (clsHoaDonBUS.XoaHD(hoaDon))
                {
                    lblXoaHDThanhCong.Visible = true;
                    XoaFormHD();
                    XoaFormCTHD();
                    CheDoSuaHD(false);
                    dtlCTSP.DataSource = null;
                    dtlCTSP.DataBind();
                    frmCTHD.Visible = false;
                }
            }
        }

        protected void dtlCTSP_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ChonCTHD")
            {
                clsCTHoaDonDTO CTHD = clsCTHoaDonBUS.LayThongTinCTHoaDon(txtMaHD.Text, e.CommandArgument.ToString());
                txtCTHDMaSP.Text = CTHD.MaSP;
                txtCTHDSoLuong.Text = CTHD.SoLuong.ToString();
                txtCTHDDonGia.Text = CTHD.DonGia.ToString();
                frmCTHD.Visible = true;
                CheDoSuaCTHD(true);
            }
            if (e.CommandName == "XoaCTHD")
            {
                clsCTHoaDonDTO CTHD = new clsCTHoaDonDTO();
                CTHD.MaHD = txtMaHD.Text;
                CTHD.MaSP = e.CommandArgument.ToString();
                int dongia = clsCTHoaDonBUS.LayDonGia(CTHD);
                if (clsCTHoaDonBUS.XoaCTHoaDon(CTHD))
                {
                    if (clsHoaDonBUS.CapNhatTongTien(txtMaHD.Text, dongia))
                    {
                        lblXoaCTHDThanhCong.Visible = true;
                    }
                }
                LoadDuLieuCTHoaDon(txtMaHD.Text);
                frmCTHD.Visible = true;
                XoaFormCTHD();
                CheDoSuaCTHD(false);

                clsHoaDonDTO HoaDon = clsHoaDonBUS.LayThongTinHD(txtMaHD.Text);
                txtTongTien.Text = HoaDon.TongTien.ToString();
            }
        }

        private void LoadDuLieuHoaDon()
        {
            grvHoaDon.DataSource = clsHoaDonBUS.LayDSHoaDon();
            grvHoaDon.DataBind();
        }

        private void LoadDuLieuCTHoaDon(string maHD)
        {
            dtlCTSP.DataSource = clsCTHoaDonBUS.LayCTHoaDon(maHD);
            dtlCTSP.DataBind();
        }

        private void CheDoSuaHD(bool status)
        {
            txtMaHD.Enabled = !status;
            txtTenTaiKhoan.Enabled = !status;
            btnHDThem.Enabled = !status;
            btnHDSua.Enabled = status;
        }

        private void CheDoSuaCTHD(bool status)
        {
            txtCTHDMaSP.Enabled = !status;
            btnCTHDThem.Enabled = !status;
            btnCTHDSua.Enabled = status;
        }

        private void XoaFormHD()
        {
            txtMaHD.Text = txtTenTaiKhoan.Text = txtNgayMua.Text = txtDiaChiGiaoHang.Text = txtSDTGiaoHang.Text = txtTongTien.Text = string.Empty;
        }

        private void XoaFormCTHD()
        {
            txtCTHDMaSP.Text = txtCTHDSoLuong.Text = txtCTHDDonGia.Text = string.Empty;
        }

        private void XoaThongBao()
        {
            lblSuaCTHDThanhCong.Visible = false;
            lblSuaHDThanhCong.Visible = false;
            lblThemCTHDThanhCong.Visible = false;
            lblThemHDThanhCong.Visible = false;
            lblThemSuaCTHDThatBai.Visible = false;
            lblThemSuaHDThatBai.Visible = false;
            lblXoaCTHDThanhCong.Visible = false;
            lblXoaHDThanhCong.Visible = false;
        }

        protected void grvHoaDon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvHoaDon.PageIndex = e.NewPageIndex;
            LoadDuLieuHoaDon();
        }

        protected void btnCTHDThem_Click(object sender, EventArgs e)
        {
            clsCTHoaDonDTO CTHD = new clsCTHoaDonDTO();
            CTHD.MaHD = txtMaHD.Text;
            CTHD.MaSP = txtCTHDMaSP.Text;
            CTHD.SoLuong = Convert.ToInt32(txtCTHDSoLuong.Text);
            CTHD.DonGia = Convert.ToInt32(txtCTHDDonGia.Text);
            if (clsCTHoaDonBUS.ThemCTHoaDon(CTHD))
            {
                LoadDuLieuCTHoaDon(CTHD.MaHD);
                frmCTHD.Visible = true;
                XoaFormCTHD();
                XoaThongBao();
                lblThemCTHDThanhCong.Visible = true;
            }
            else
            {
                XoaThongBao();
                lblThemSuaCTHDThatBai.Visible = true;
                frmCTHD.Visible = true;
            }
        }

        protected void btnCTHDSua_Click(object sender, EventArgs e)
        {
            clsCTHoaDonDTO CTHD = new clsCTHoaDonDTO();
            CTHD.MaHD = txtMaHD.Text;
            CTHD.MaSP = txtCTHDMaSP.Text;
            CTHD.SoLuong = Convert.ToInt32(txtCTHDSoLuong.Text);
            CTHD.DonGia = Convert.ToInt32(txtCTHDDonGia.Text);
            if (clsCTHoaDonBUS.SuaCTHoaDon(CTHD))
            {
                LoadDuLieuCTHoaDon(txtMaHD.Text);
                XoaFormCTHD();
                XoaThongBao();
                frmCTHD.Visible = true;
                lblSuaCTHDThanhCong.Visible = true;
            }
            else
            {
                frmCTHD.Visible = true;
                XoaThongBao();
                lblThemSuaCTHDThatBai.Visible = true;
            }
        }

        protected void btnCTHDHuy_Click(object sender, EventArgs e)
        {
            txtCTHDMaSP.Text = txtCTHDSoLuong.Text = txtCTHDDonGia.Text = string.Empty;
            CheDoSuaCTHD(false);
            XoaThongBao();
            frmCTHD.Visible = true;
        }

        protected void btnHDThem_Click(object sender, EventArgs e)
        {
            clsHoaDonDTO hoaDonDTO = new clsHoaDonDTO();
            hoaDonDTO.MaHD = txtMaHD.Text;
            hoaDonDTO.TenTaiKhoan = txtTenTaiKhoan.Text;
            hoaDonDTO.NgayMua = Convert.ToDateTime(txtNgayMua.Text);
            hoaDonDTO.DiaChiGiaoHang = txtDiaChiGiaoHang.Text;
            hoaDonDTO.SDTGiaoHang = txtSDTGiaoHang.Text;
            hoaDonDTO.TongTien = Convert.ToInt32(txtTongTien.Text);
            hoaDonDTO.TrangThai = true;
            if (clsHoaDonBUS.ThemHD(hoaDonDTO))
            {
                XoaFormHD();
                XoaThongBao();
                LoadDuLieuHoaDon();
                lblThemHDThanhCong.Visible = true;
            }
            else
            {
                XoaThongBao();
                lblThemSuaHDThatBai.Visible = true;
            }
        }

        protected void btnHDSua_Click(object sender, EventArgs e)
        {
            clsHoaDonDTO hoaDonDTO = new clsHoaDonDTO();
            hoaDonDTO.MaHD = txtMaHD.Text;
            hoaDonDTO.TenTaiKhoan = txtTenTaiKhoan.Text;
            hoaDonDTO.NgayMua = Convert.ToDateTime(txtNgayMua.Text);
            hoaDonDTO.DiaChiGiaoHang = txtDiaChiGiaoHang.Text;
            hoaDonDTO.SDTGiaoHang = txtSDTGiaoHang.Text;
            hoaDonDTO.TongTien = Convert.ToInt32(txtTongTien.Text);
            hoaDonDTO.TrangThai = true;
            if (clsHoaDonBUS.SuaHD(hoaDonDTO))
            {
                dtlCTSP.DataSource = null;
                dtlCTSP.DataBind();
                XoaFormHD();
                XoaThongBao();
                CheDoSuaHD(false);
                LoadDuLieuHoaDon();
                lblSuaHDThanhCong.Visible = true;
            }
            else
            {
                XoaThongBao();
                lblThemSuaHDThatBai.Visible = true;
            }
        }

        protected void btnHDHuy_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = txtTenTaiKhoan.Text = txtNgayMua.Text = txtDiaChiGiaoHang.Text = txtSDTGiaoHang.Text = txtTongTien.Text = String.Empty;
            CheDoSuaHD(false);
            XoaThongBao();
            frmCTHD.Visible = false;
        }
    }
}