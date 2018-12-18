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
    public partial class QLLoaiSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDuLieuLoaiSanPham();
            }
            XoaThongBao();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            clsLoaiSPDTO LoaiSP = new clsLoaiSPDTO();
            LoaiSP.MaLoaiSP = txtMaLoaiSP.Text;
            LoaiSP.TenLoaiSP = txtTenLoaiSP.Text;
            LoaiSP.TrangThai = chkTrangThai.Checked;
            if (clsLoaiSPBUS.ThemLoaiSP(LoaiSP))
            {
                LoadDuLieuLoaiSanPham();
                lblThemThanhCong.Visible = true;
                XoaForm();
            }
            else
            {
                lblThemThatBai.Visible = true;
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            clsLoaiSPDTO LoaiSP = new clsLoaiSPDTO();
            LoaiSP.MaLoaiSP = txtMaLoaiSP.Text;
            LoaiSP.TenLoaiSP = txtTenLoaiSP.Text;
            LoaiSP.TrangThai = chkTrangThai.Checked;
            if (clsLoaiSPBUS.SuaLoaiSP(LoaiSP))
            {
                LoadDuLieuLoaiSanPham();
                lblSuaThanhCong.Visible = true;
                XoaForm();
            }
            else
            {
                XoaThongBao();
                lblSuaThatBai.Visible = true;
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            XoaForm();
            XoaThongBao();
            CheDoSua(false);
        }

        protected void grvLoaiSanPham_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Chon")
            {
                clsLoaiSPDTO LoaiSP = clsLoaiSPBUS.LayLoaiSP(e.CommandArgument.ToString());
                txtMaLoaiSP.Text = LoaiSP.MaLoaiSP;
                txtTenLoaiSP.Text = LoaiSP.TenLoaiSP;
                chkTrangThai.Checked = LoaiSP.TrangThai;
                CheDoSua(true);
            }
            if (e.CommandName == "Xoa")
            {
                clsLoaiSPBUS.XoaLoaiSP(e.CommandArgument.ToString());
                LoadDuLieuLoaiSanPham();
                lblXoaThanhCong.Visible = true;
            }
        }

        private void LoadDuLieuLoaiSanPham()
        {
            grvLoaiSanPham.DataSource = clsLoaiSPBUS.LayDSLoaiSP_AdminCP();
            grvLoaiSanPham.DataBind();
            CheDoSua(false);
            XoaForm();
            XoaThongBao();
        }

        private void XoaThongBao()
        {
            lblThemThanhCong.Visible = false;
            lblThemThatBai.Visible = false;
            lblXoaThanhCong.Visible = false;
            lblSuaThanhCong.Visible = false;
            lblSuaThatBai.Visible = false;
        }

        private void XoaForm()
        {
            txtMaLoaiSP.Text = txtTenLoaiSP.Text = string.Empty;
            chkTrangThai.Checked = false;
        }

        private void CheDoSua(bool status)
        {
            txtMaLoaiSP.Enabled = !status;
        }

        protected void grvLoaiSanPham_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvLoaiSanPham.PageIndex = e.NewPageIndex;
            LoadDuLieuLoaiSanPham();
        }
    }
}