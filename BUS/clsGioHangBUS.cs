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
    public class clsGioHangBUS
    {
        public static int DemSoLuongSanPhamTrongGH(string tenTK)
        {
            if (clsGioHangDAO.KiemTraCoSanPhamTrongGH(tenTK))
            {
                return clsGioHangDAO.DemSoLuongSanPhamTrongGH(tenTK);

            }
            return 0;
        }

        public static DataTable LayGioHang(string tenTK)
        {
            return clsGioHangDAO.LayGioHang(tenTK);
        }

        public static int TinhTongTien(string tenTK)
        {
            return clsGioHangDAO.TinhTongTien(tenTK);
        }

        public static bool ThemSPVaoGH(clsGioHangDTO gioHangDTO)
        {
            // Nếu sản phẩm còn hàng => Tiếp tục
            if (clsGioHangDAO.LaySoLuongSP(gioHangDTO) + gioHangDTO.SoLuong <= clsSanPhamBUS.LayThongTinSP(gioHangDTO.MaSP).SoLuongTonKho)
            {
                // Nếu SP đã tồn tại trong GH => Cập nhật số lượng
                if (clsGioHangDAO.KiemTraSPTonTai(gioHangDTO))
                {
                    return clsGioHangDAO.CapNhatSoLuongSP(gioHangDTO);
                }
                // Ngược lại => Thêm SP vào GH
                else
                {
                    return clsGioHangDAO.ThemSPVaoGH(gioHangDTO);
                }
            }
            // Ngược lại => Thêm SP vào GH thất bại
            else
            {
                return false;
            }
        }

        public static bool XoaSP(clsGioHangDTO gioHangDTO)
        {
            return clsGioHangDAO.XoaSP(gioHangDTO);
        }

        public static bool KiemTraSoLuongSPTrongGH(string tenTK)
        {
            DataTable dtbGioHang = clsGioHangDAO.LayGioHang(tenTK);
            foreach (DataRow dr in dtbGioHang.Rows)
            {
                string maSP = dr["MaSP"].ToString();
                int soLuong = Convert.ToInt32(dr["SoLuong"]);
                int soLuongTonKho = clsSanPhamBUS.LayThongTinSP(maSP).SoLuongTonKho;
                if (soLuong > soLuongTonKho)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
