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
    public partial class ThanhToan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Người dùng chưa đăng nhập
            if (Request.Cookies["TaiKhoan"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnThanhToan_Click(object sender, EventArgs e)
        {
            clsHoaDonDTO hoaDonDTO = new clsHoaDonDTO();
            hoaDonDTO.MaHD = "";
            hoaDonDTO.TenTaiKhoan = Request.Cookies["TaiKhoan"]["TenTaiKhoan"];
            hoaDonDTO.NgayMua = DateTime.Now;
            hoaDonDTO.DiaChiGiaoHang = txtDiaChiGiaoHang.Text;
            hoaDonDTO.SDTGiaoHang = txtSDTGiaoHang.Text;
            hoaDonDTO.TongTien = clsGioHangBUS.TinhTongTien(hoaDonDTO.TenTaiKhoan);
            hoaDonDTO.TrangThai = true;

            // Thêm HĐ thành công
            if (clsHoaDonBUS.ThemHD(hoaDonDTO))
            {
                lblThanhToanThanhCong.Visible = true;
                lblThanhToanThatBai.Visible = false;

                Label SoGH = (Label)Master.FindControl("lblSoLuongGioHang");
                SoGH.Text = "0";
            }
            // Ngược lại => Báo lỗi
            else
            {
                lblThanhToanThatBai.Visible = true;
                lblThanhToanThanhCong.Visible = false;
            }
        }
    }
}