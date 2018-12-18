using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class clsHoaDonBUS
    {
        public static bool ThemHD(clsHoaDonDTO hoaDonDTO)
        {
            // Lấy giỏ hàng
            DataTable dtbGioHang = clsGioHangDAO.LayGioHang(hoaDonDTO.TenTaiKhoan);

            hoaDonDTO.MaHD = (clsHoaDonDAO.LayMaHDLonNhat() + 1).ToString();

            // Nếu tất cả sản phẩm trong giỏ hàng đều đủ số lượng để mua
            if (clsGioHangBUS.KiemTraSoLuongSPTrongGH(hoaDonDTO.TenTaiKhoan))
            {
                // Thêm hóa đơn
                if (!clsHoaDonDAO.ThemHoaDon(hoaDonDTO))
                {
                    return false;
                }

                // Thêm sản phẩm vào CTHD
                foreach (DataRow dr in dtbGioHang.Rows)
                {
                    clsSanPhamDTO sanPhamDTO = clsSanPhamBUS.LayThongTinSP(dr["MaSP"].ToString());

                    clsCTHoaDonDTO ctHoaDonDTO = new clsCTHoaDonDTO();
                    ctHoaDonDTO.MaHD = hoaDonDTO.MaHD;
                    ctHoaDonDTO.MaSP = dr["MaSP"].ToString();
                    ctHoaDonDTO.SoLuong = Convert.ToInt32(dr["SoLuong"]);
                    ctHoaDonDTO.DonGia = sanPhamDTO.GiaTien;

                    clsCTHoaDonDAO.ThemCTHoaDon(ctHoaDonDTO);

                    // Cập nhật số lượng tồn kho
                    sanPhamDTO.SoLuongTonKho -= ctHoaDonDTO.SoLuong;
                    clsSanPhamDAO.SuaSanPham(sanPhamDTO);
                }
                clsGioHangDAO.XoaGioHang(hoaDonDTO.TenTaiKhoan);

                return true;
            }
            // Ngược lại => Báo lỗi
            else
            {
                return false;
            }
        }

        public static bool SuaHD(clsHoaDonDTO hoaDonDTO)
        {
            return clsHoaDonDAO.SuaHoaDon(hoaDonDTO);
        }

        public static DataTable LayDSHoaDon()
        {
            return clsHoaDonDAO.LayDSHoaDon();
        }

        public static DataTable LayLichSuGiaoDich(string tenTK)
        {
            return clsHoaDonDAO.LayLichSuGiaoDich(tenTK);
        }

        public static clsHoaDonDTO LayThongTinHD(string maHD)
        {
            DataRow dr = clsHoaDonDAO.LayThongTinHD(maHD);
            clsHoaDonDTO HoaDon = new clsHoaDonDTO();
            HoaDon.MaHD = dr["MaHD"].ToString();
            HoaDon.TenTaiKhoan = dr["TenTaiKhoan"].ToString();
            HoaDon.NgayMua = Convert.ToDateTime(dr["NgayMua"]);
            HoaDon.DiaChiGiaoHang = dr["DiaChiGiaoHang"].ToString();
            HoaDon.SDTGiaoHang = dr["SDTGiaoHang"].ToString();
            HoaDon.TongTien = Convert.ToInt32(dr["TongTien"]);
            HoaDon.TrangThai = Convert.ToBoolean(dr["TrangThai"]);
            return HoaDon;
        }

        public static bool CapNhatTongTien(string maHD, int donGia)
        {
            return clsHoaDonDAO.CapNhatTongTienHoaDon(maHD, donGia);
        }

        public static bool XoaHD(clsHoaDonDTO hoaDon)
        {
            return clsHoaDonDAO.XoaHoaDon(hoaDon);
        }
    }
}
