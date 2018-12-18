using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsLoaiSPDAO
    {
        public static DataTable LayDSLoaiSP_AdminCP()
        {
            string query = "SELECT * FROM tblLoaiSanPham";
            SqlParameter[] parameter = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static DataTable LayDSLoaiSP()
        {
            string query = "SELECT * FROM tblLoaiSanPham WHERE TrangThai=1";
            SqlParameter[] parameter = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static DataRow LayLoaiSP(string maLoaiSP)
        {
            string query = "SELECT * FROM tblLoaiSanPham WHERE MaLoaiSP=@MaLoaiSP";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@MaLoaiSP", maLoaiSP);
            return DataProvider.ExecuteSelectQuery(query, parameter).Rows[0];
        }

        public static bool KiemTraLoaiSPTonTai(string maLoaiSP)
        {
            string query = "SELECT COUNT(*) FROM tblLoaiSanPham WHERE MaLoaiSP=@MaLoaiSP";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@MaLoaiSP", maLoaiSP);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]) == 1;
        }

        public static bool ThemLoaiSP(clsLoaiSPDTO LoaiSP)
        {
            string query = "INSERT INTO tblLoaiSanPham(MaLoaiSP, TenLoaiSP, TrangThai) VALUES (@MaLoaiSP, @TenLoaiSP, @TrangThai)";
            SqlParameter[] parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@MaLoaiSP", LoaiSP.MaLoaiSP);
            parameter[1] = new SqlParameter("@TenLoaiSP", LoaiSP.TenLoaiSP);
            parameter[2] = new SqlParameter("@TrangThai", LoaiSP.TrangThai);
            return DataProvider.ExecuteInsertQuery(query, parameter) == 1;
        }

        public static bool SuaLoaiSP(clsLoaiSPDTO LoaiSP)
        {
            string query = "UPDATE tblLoaiSanPham SET TenLoaiSP=@TenLoaiSP, TrangThai=@TrangThai WHERE MaLoaiSP=@MaLoaiSP";
            SqlParameter[] parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@MaLoaiSP", LoaiSP.MaLoaiSP);
            parameter[1] = new SqlParameter("@TenLoaiSP", LoaiSP.TenLoaiSP);
            parameter[2] = new SqlParameter("@TrangThai", LoaiSP.TrangThai);
            return DataProvider.ExecuteUpdateQuery(query, parameter) == 1;
        }

        public static bool XoaLoaiSP(string maLoaiSP)
        {
            string query = "DELETE FROM tblLoaiSanPham WHERE MaLoaiSP=@MaLoaiSP";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@MaLoaiSP", maLoaiSP);
            return DataProvider.ExecuteDeleteQuery(query, parameter) == 1;
        }
    }
}
