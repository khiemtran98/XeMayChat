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
    public class clsCTHoaDonBUS
    {
        public static bool ThemCTHoaDon(clsCTHoaDonDTO ctHoaDonDTO)
        {
            return clsCTHoaDonDAO.ThemCTHoaDon(ctHoaDonDTO);
        }

        public static bool SuaCTHoaDon(clsCTHoaDonDTO ctHoaDonDTO)
        {
            return clsCTHoaDonDAO.SuaCTHoaDon(ctHoaDonDTO);
        }

        public static DataTable LayCTHoaDon(string maHD)
        {
            return clsCTHoaDonDAO.LayCTHoaDon(maHD);
        }

        public static clsCTHoaDonDTO LayThongTinCTHoaDon(string maHD, string maSP)
        {
            DataRow dr = clsCTHoaDonDAO.LayThongTinCTHoaDon(maHD, maSP);
            clsCTHoaDonDTO CTHD = new clsCTHoaDonDTO();
            CTHD.MaSP = dr["MaSP"].ToString();
            CTHD.SoLuong = Convert.ToInt32(dr["SoLuong"]);
            CTHD.DonGia = Convert.ToInt32(dr["DonGia"]);
            return CTHD;
        }

        public static int LayDonGia(clsCTHoaDonDTO CTHD)
        {
            return clsCTHoaDonDAO.LayDonGia(CTHD);
        }

        public static bool XoaCTHoaDon(clsCTHoaDonDTO ctHoaDonDTO)
        {
            return clsCTHoaDonDAO.XoaCTHoaDon(ctHoaDonDTO);
        }
    }
}
