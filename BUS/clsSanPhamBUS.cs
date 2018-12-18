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
    public class clsSanPhamBUS
    {
        public static DataTable LayDSSanPham_AdminCP()
        {
            return clsSanPhamDAO.LayDSSanPham_AdminCP();
        }

        public static DataTable LayDSSanPhamTheoLoai_AdminCP(string maLoaiSP)
        {
            return clsSanPhamDAO.LayDSSanPhamTheoLoai_AdminCP(maLoaiSP);
        }

        public static DataTable LayDSSanPham()
        {
            return clsSanPhamDAO.LayDSSanPham();
        }

        public static DataTable LayDSSanPhamTheoLoai(string maLoaiSP)
        {
            return clsSanPhamDAO.LayDSSanPhamTheoLoai(maLoaiSP);
        }

        public static clsSanPhamDTO LayThongTinSP(string maSP)
        {
            DataRow dr = clsSanPhamDAO.LaySanPham(maSP);
            clsSanPhamDTO SanPham = new clsSanPhamDTO();
            SanPham.MaSP = dr["MaSP"].ToString();
            SanPham.TenSP = dr["TenSP"].ToString();
            SanPham.ThongTin = dr["ThongTin"].ToString();
            SanPham.GiaTien = Convert.ToInt32(dr["GiaTien"]);
            SanPham.SoLuongTonKho = Convert.ToInt32(dr["SoLuongTonKho"]);
            SanPham.MaLoaiSP = dr["MaLoaiSP"].ToString();
            SanPham.AnhMinhHoa = dr["AnhMinhHoa"].ToString();
            SanPham.TrangThai = Convert.ToBoolean(dr["TrangThai"]);
            return SanPham;
        }

        public static bool ThemSanPham(clsSanPhamDTO SanPham)
        {
            if (!clsSanPhamDAO.KiemTraSPTonTai(SanPham.MaSP))
            {
                return clsSanPhamDAO.ThemSanPham(SanPham);
            }
            return false;
        }

        public static bool SuaSanPham(clsSanPhamDTO SanPham)
        {
            return clsSanPhamDAO.SuaSanPham(SanPham);
        }

        public static bool XoaSanPham(string maSP)
        {
            return clsSanPhamDAO.XoaSanPham(maSP);
        }

        public static DataTable TimKiemSanPham(string tuKhoa)
        {
            return clsSanPhamDAO.TimKiemSanPham(tuKhoa);
        }
    }
}
