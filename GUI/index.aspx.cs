using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DTO;

namespace GUI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataView dtv;
            if (Request.QueryString["TimKiem"] != null)
            {
                dtv = clsSanPhamBUS.TimKiemSanPham(Request.QueryString["TimKiem"]).DefaultView;
                cprDSTrang.DataSource = dtv;
                cprDSTrang.BindToControl = dtlDSSanPham;
                dtlDSSanPham.DataSource = cprDSTrang.DataSourcePaged;
                if (dtv.Count == 0)
                {
                    lblThongBao.Visible = true;
                }
                else
                {
                    lblThongBao.Visible = false;
                }
            }
            else
            {
                if (Request.QueryString["HSX"] != null)
                {
                    dtv = clsSanPhamBUS.LayDSSanPhamTheoLoai(Request.QueryString["HSX"]).DefaultView;
                    cprDSTrang.DataSource = dtv;
                    cprDSTrang.BindToControl = dtlDSSanPham;
                    dtlDSSanPham.DataSource = cprDSTrang.DataSourcePaged;
                    if (dtv.Count == 0)
                    {
                        lblThongBao.Visible = true;
                    }
                    else
                    {
                        lblThongBao.Visible = false;
                    }
                }
                else
                {
                    dtv = clsSanPhamBUS.LayDSSanPham().DefaultView;
                    cprDSTrang.DataSource = dtv;
                    cprDSTrang.BindToControl = dtlDSSanPham;
                    dtlDSSanPham.DataSource = cprDSTrang.DataSourcePaged;
                    if (dtv.Count == 0)
                    {
                        lblThongBao.Visible = true;
                    }
                    else
                    {
                        lblThongBao.Visible = false;
                    }
                }
            }
        }

        protected void dtlDSSanPham_ItemCommand(object source, DataListCommandEventArgs e)
        {
            // Xử lí nút Thêm vào giỏ hàng
            if (e.CommandName == "ThemGH")
            {
                // Người dùng đã đăng nhập => Thêm SP vào GH
                if (Request.Cookies["TaiKhoan"] != null)
                {
                    clsGioHangDTO gioHangDTO = new clsGioHangDTO();
                    gioHangDTO.TenTaiKhoan = Request.Cookies["TaiKhoan"]["TenTaiKhoan"];
                    gioHangDTO.MaSP = e.CommandArgument.ToString();
                    gioHangDTO.SoLuong = 1;

                    // Thêm SP vào GH thành công
                    if (clsGioHangBUS.ThemSPVaoGH(gioHangDTO))
                    {
                        Label SoSPTrongGH = (Label)this.Master.FindControl("lblSoLuongGioHang");
                        SoSPTrongGH.Text = clsGioHangBUS.DemSoLuongSanPhamTrongGH(Request.Cookies["TaiKhoan"]["TenTaiKhoan"].ToString()).ToString();
                    }
                    // Ngược lại => Thông báo lỗi
                    else
                    {
                        Response.Write("<script>alert('Số lượng sản phẩm trong kho không đủ');</script>");
                    }
                }
                // Ngược lại => Thông báo lỗi: Yêu cầu đăng nhập
                else
                {
                    Response.Write("<script>alert('Vui lòng đăng nhập để mua hàng');</script>");
                }
            }
        }
    }
}