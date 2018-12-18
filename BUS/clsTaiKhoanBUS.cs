using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class clsTaiKhoanBUS
    {
        public static DataTable LayDSTaiKhoan()
        {
            return clsTaiKhoanDAO.LayDSTaiKhoan();
        }

        public static clsTaiKhoanDTO LayTK(string tenTK)
        {
            DataRow dr = clsTaiKhoanDAO.LayTK(tenTK);

            clsTaiKhoanDTO taiKhoanDTO = new clsTaiKhoanDTO();
            taiKhoanDTO.TenTaiKhoan = dr["TenTaiKhoan"].ToString();
            taiKhoanDTO.MatKhau = dr["MatKhau"].ToString();
            taiKhoanDTO.Email = dr["Email"].ToString();
            taiKhoanDTO.SDT = dr["SDT"].ToString();
            taiKhoanDTO.DiaChi = dr["DiaChi"].ToString();
            taiKhoanDTO.HoTen = dr["HoTen"].ToString();
            taiKhoanDTO.LaAdmin = Convert.ToBoolean(dr["LaAdmin"]);
            taiKhoanDTO.AnhDaiDien = dr["AnhDaiDien"].ToString();
            taiKhoanDTO.TrangThai = Convert.ToBoolean(dr["TrangThai"]);

            return taiKhoanDTO;
        }

        public static bool ThemTK(clsTaiKhoanDTO taiKhoanDTO)
        {
            if (!clsTaiKhoanDAO.KiemTraTKTonTai(taiKhoanDTO.TenTaiKhoan))
            {
                return clsTaiKhoanDAO.ThemTK(taiKhoanDTO);
            }
            else
            {
                return false;
            }
        }

        public static bool SuaTK(clsTaiKhoanDTO taiKhoanDTO)
        {
            return clsTaiKhoanDAO.SuaTK(taiKhoanDTO);
        }

        public static bool KiemTraDangNhap(string tenTK, string mK)
        {
            if (clsTaiKhoanDAO.KiemTraTKTonTai(tenTK))
            {
                return mK == clsTaiKhoanDAO.LayMatKhau(tenTK);
            }
            else
            {
                return false;
            }
        }

        public static string LayMatKhau(string tenTK)
        {
            return clsTaiKhoanDAO.LayMatKhau(tenTK);
        }

        public static string LayHoTen(string tenTK)
        {
            return clsTaiKhoanDAO.LayHoTen(tenTK);
        }

        public static bool DoiMatKhau(string tenTK, string mKMoi)
        {
            return clsTaiKhoanDAO.SuaMatKhau(tenTK, mKMoi);
        }

        public static bool XoaTK(string tenTK)
        {
            return clsTaiKhoanDAO.XoaTK(tenTK);
        }

        public static bool XoaAnhDaiDien(clsTaiKhoanDTO TaiKhoan)
        {
            return clsTaiKhoanDAO.XoaAnhDaiDien(TaiKhoan);
        }
    }
}
