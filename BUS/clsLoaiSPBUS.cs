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
    public class clsLoaiSPBUS
    {
        public static DataTable LayDSLoaiSP_AdminCP()
        {
            return clsLoaiSPDAO.LayDSLoaiSP_AdminCP();
        }

        public static DataTable LayDSLoaiSP()
        {
            return clsLoaiSPDAO.LayDSLoaiSP();
        }

        public static clsLoaiSPDTO LayLoaiSP(string maLoaiSP)
        {
            DataRow dr = clsLoaiSPDAO.LayLoaiSP(maLoaiSP);
            clsLoaiSPDTO LoaiSP = new clsLoaiSPDTO();
            LoaiSP.MaLoaiSP = dr["MaLoaiSP"].ToString();
            LoaiSP.TenLoaiSP = dr["TenLoaiSP"].ToString();
            LoaiSP.TrangThai = Convert.ToBoolean(dr["TrangThai"]);
            return LoaiSP;
        }

        public static bool KiemTraLoaiSPTonTai(string maLoaiSP)
        {
            return clsLoaiSPDAO.KiemTraLoaiSPTonTai(maLoaiSP);
        }

        public static bool ThemLoaiSP(clsLoaiSPDTO LoaiSP)
        {
            if (!clsLoaiSPDAO.KiemTraLoaiSPTonTai(LoaiSP.MaLoaiSP))
            {
                return clsLoaiSPDAO.ThemLoaiSP(LoaiSP);
            }
            return false;
        }

        public static bool SuaLoaiSP(clsLoaiSPDTO LoaiSP)
        {
            return clsLoaiSPDAO.SuaLoaiSP(LoaiSP);
        }

        public static bool XoaLoaiSP(string maLoaiSP)
        {
            return clsLoaiSPDAO.XoaLoaiSP(maLoaiSP);
        }
    }
}
