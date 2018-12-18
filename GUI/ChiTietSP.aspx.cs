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
    public partial class ChiTietSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MaSP"] != null)
            {
                string maSP = Request.QueryString["MaSP"];

                clsSanPhamDTO sanPhamDTO = clsSanPhamBUS.LayThongTinSP(maSP);

                if (sanPhamDTO != null)
                {
                    imgAnhMinhHoa.ImageUrl = "img/AnhMinhHoa/" + sanPhamDTO.AnhMinhHoa;
                    lblTenSP.Text = sanPhamDTO.TenSP;
                    lblThongTin.Text = sanPhamDTO.ThongTin;
                    lblGiaTien.Text = sanPhamDTO.GiaTien.ToString();
                    lblSoLuongTonKho.Text = sanPhamDTO.SoLuongTonKho.ToString();
                    TenTrang.InnerText = lblTenSP.Text;
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnThemVaoGH_Click(object sender, EventArgs e)
        {
            // Người dùng đã đăng nhập => Thêm SP vào GH
            if (Request.Cookies["TaiKhoan"] != null)
            {
                clsGioHangDTO gioHangDTO = new clsGioHangDTO();
                gioHangDTO.TenTaiKhoan = Request.Cookies["TaiKhoan"]["TenTaiKhoan"];
                gioHangDTO.MaSP = Request.QueryString["MaSP"];
                gioHangDTO.SoLuong = Convert.ToInt32(txtSoLuongMua.Text);

                // Thêm SP vào GH thành công
                if (clsGioHangBUS.ThemSPVaoGH(gioHangDTO))
                {
                    lblThongBaoThanhCong.Text = "Thêm sản phẩm vào giỏ hàng thành công";
                    lblThongBaoThanhCong.Visible = true;
                    lblThongBaoThatBai.Visible = false;
                    Label SoSPTrongGH = (Label)this.Master.FindControl("lblSoLuongGioHang");
                    SoSPTrongGH.Text = clsGioHangBUS.DemSoLuongSanPhamTrongGH(Request.Cookies["TaiKhoan"]["TenTaiKhoan"].ToString()).ToString();
                }
                // Ngược lại => Thông báo lỗi
                else
                {
                    lblThongBaoThatBai.Text = "Số lượng sản phẩm trong kho không đủ";
                    lblThongBaoThatBai.Visible = true;
                    lblThongBaoThanhCong.Visible = false;
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