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
    public class clsCTHoaDonDAO
    {
        public static bool ThemCTHoaDon(clsCTHoaDonDTO ctHoaDonDTO)
        {
            string query = "INSERT INTO tblCTHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";
            SqlParameter[] parameter = new SqlParameter[4];
            parameter[0] = new SqlParameter("@MaHD", ctHoaDonDTO.MaHD);
            parameter[1] = new SqlParameter("@MaSP", ctHoaDonDTO.MaSP);
            parameter[2] = new SqlParameter("@SoLuong", ctHoaDonDTO.SoLuong);
            parameter[3] = new SqlParameter("@DonGia", ctHoaDonDTO.DonGia);
            return DataProvider.ExecuteInsertQuery(query, parameter) == 1;
        }

        public static bool SuaCTHoaDon(clsCTHoaDonDTO ctHoaDonDTO)
        {
            string query = "UPDATE tblCTHoaDon SET SoLuong=@SoLuong, DonGia=@DonGia WHERE MaHD=@MaHD AND MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[4];
            parameter[0] = new SqlParameter("@MaHD", ctHoaDonDTO.MaHD);
            parameter[1] = new SqlParameter("@MaSP", ctHoaDonDTO.MaSP);
            parameter[2] = new SqlParameter("@SoLuong", ctHoaDonDTO.SoLuong);
            parameter[3] = new SqlParameter("@DonGia", ctHoaDonDTO.DonGia);
            return DataProvider.ExecuteUpdateQuery(query, parameter) == 1;
        }

        public static DataTable LayCTHoaDon(string maHD)
        {
            string query = "SELECT * FROM tblCTHoaDon WHERE MaHD=@MaHD";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@MaHD", maHD);
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static int LayDonGia(clsCTHoaDonDTO CTHD)
        {
            string query = "SELECT DonGia FROM tblCTHoaDon WHERE MaHD=@MaHD AND MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@MaHD", CTHD.MaHD);
            parameter[1] = new SqlParameter("@MaSP", CTHD.MaSP);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]);
        }

        public static DataRow LayThongTinCTHoaDon(string maHD, string maSP)
        {
            string query = "SELECT * FROM tblCTHoaDon WHERE MaHD=@MaHD AND MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@MaHD", maHD);
            parameter[1] = new SqlParameter("@MaSP", maSP);
            return DataProvider.ExecuteSelectQuery(query, parameter).Rows[0];
        }

        public static bool XoaCTHoaDon(clsCTHoaDonDTO ctHoaDonDTO)
        {
            string query = "DELETE FROM tblCTHoaDon WHERE MaHD=@MaHD AND MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@MaHD", ctHoaDonDTO.MaHD);
            parameter[1] = new SqlParameter("@MaSP", ctHoaDonDTO.MaSP);
            return DataProvider.ExecuteDeleteQuery(query, parameter) == 1;
        }
    }
}
