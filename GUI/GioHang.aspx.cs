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
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Người dùng đã đăng nhập => Load giỏ hàng
                if (Request.Cookies["TaiKhoan"] != null)
                {
                    string tenTK = Request.Cookies["TaiKhoan"]["TenTaiKhoan"];
                    LoadGioHang(tenTK);
                }
                // Ngược lại => Chuyển về trang chủ
                else
                {
                    Response.Redirect("index.aspx");
                }
                if (grvGioHang.Rows.Count == 0)
                {
                    btnThanhToan.Enabled = false;
                }
                else
                {
                    btnThanhToan.Enabled = true;
                }
            }
        }

        protected void grvGioHang_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XoaSP")
            {
                clsGioHangDTO gioHangDTO = new clsGioHangDTO();
                gioHangDTO.TenTaiKhoan = Request.Cookies["TaiKhoan"]["TenTaiKhoan"];
                gioHangDTO.MaSP = e.CommandArgument.ToString();
                gioHangDTO.SoLuong = 0;

                // Xóa thành công
                if (clsGioHangBUS.XoaSP(gioHangDTO))
                {
                    LoadGioHang(gioHangDTO.TenTaiKhoan);
                    Label SoSPTrongGH = (Label)this.Master.FindControl("lblSoLuongGioHang");
                    SoSPTrongGH.Text = clsGioHangBUS.DemSoLuongSanPhamTrongGH(Request.Cookies["TaiKhoan"]["TenTaiKhoan"].ToString()).ToString();
                    if (grvGioHang.Rows.Count == 0)
                    {
                        btnThanhToan.Enabled = false;
                    }
                }
                // Xóa thất bại
                else
                {
                    Response.Write("<script>Xóa sản phẩm thất bại!</script>");
                }
            }
        }

        private void LoadGioHang(string tenTK)
        {
            grvGioHang.DataSource = clsGioHangBUS.LayGioHang(tenTK);
            grvGioHang.DataBind();
            lblTongTien.Text = clsGioHangBUS.TinhTongTien(tenTK).ToString() + " VND";
        }

        protected void btnThanhToan_Click(object sender, EventArgs e)
        {
            string tenTK = Request.Cookies["TaiKhoan"]["TenTaiKhoan"];

            // Nếu tất cả sản phẩm trong giỏ hàng đều đủ số lượng để mua
            if (clsGioHangBUS.KiemTraSoLuongSPTrongGH(tenTK))
            {
                Response.Redirect("ThanhToan.aspx");
            }
            // Ngược lại => Thông báo lỗi
            else
            {
                Response.Write("<script>alert('Trong giỏ hàng có sản phẩm không đủ số lượng để mua!');</script>");
            }
        }
    }
}