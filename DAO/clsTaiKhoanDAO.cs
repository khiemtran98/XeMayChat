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
    public class clsTaiKhoanDAO
    {
        public static DataTable LayDSTaiKhoan()
        {
            string query = "SELECT * FROM tblTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static DataRow LayTK(string tenTK)
        {
            string query = "SELECT * FROM tblTaiKhoan WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return DataProvider.ExecuteSelectQuery(query, parameter).Rows[0];
        }

        public static bool ThemTK(clsTaiKhoanDTO taiKhoanDTO)
        {
            string query = "INSERT INTO tblTaiKhoan (TenTaiKhoan, MatKhau, Email, SDT, DiaChi, HoTen, LaAdmin, AnhDaiDien, TrangThai) VALUES (@TenTaiKhoan, @MatKhau, @Email, @SDT, @DiaChi, @HoTen, @LaAdmin, @AnhDaiDien, @TrangThai)";
            SqlParameter[] parameter = new SqlParameter[9];
            parameter[0] = new SqlParameter("@TenTaiKhoan", taiKhoanDTO.TenTaiKhoan);
            parameter[1] = new SqlParameter("@MatKhau", taiKhoanDTO.MatKhau);
            parameter[2] = new SqlParameter("@Email", taiKhoanDTO.Email);
            parameter[3] = new SqlParameter("@SDT", taiKhoanDTO.SDT);
            parameter[4] = new SqlParameter("@DiaChi", taiKhoanDTO.DiaChi);
            parameter[5] = new SqlParameter("@HoTen", taiKhoanDTO.HoTen);
            parameter[6] = new SqlParameter("@LaAdmin", taiKhoanDTO.LaAdmin);
            parameter[7] = new SqlParameter("@AnhDaiDien", taiKhoanDTO.AnhDaiDien);
            parameter[8] = new SqlParameter("@TrangThai", taiKhoanDTO.TrangThai);
            return DataProvider.ExecuteInsertQuery(query, parameter) == 1;
        }

        public static bool SuaTK(clsTaiKhoanDTO taiKhoanDTO)
        {
            string query = "UPDATE tblTaiKhoan SET MatKhau=@MatKhau, Email=@Email, SDT=@SDT, DiaChi=@DiaChi, HoTen=@HoTen, LaAdmin=@LaAdmin, AnhDaiDien=@AnhDaiDien, TrangThai=@TrangThai WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[9];
            parameter[0] = new SqlParameter("@TenTaiKhoan", taiKhoanDTO.TenTaiKhoan);
            parameter[1] = new SqlParameter("@MatKhau", taiKhoanDTO.MatKhau);
            parameter[2] = new SqlParameter("@Email", taiKhoanDTO.Email);
            parameter[3] = new SqlParameter("@SDT", taiKhoanDTO.SDT);
            parameter[4] = new SqlParameter("@DiaChi", taiKhoanDTO.DiaChi);
            parameter[5] = new SqlParameter("@HoTen", taiKhoanDTO.HoTen);
            parameter[6] = new SqlParameter("@LaAdmin", taiKhoanDTO.LaAdmin);
            parameter[7] = new SqlParameter("@AnhDaiDien", taiKhoanDTO.AnhDaiDien);
            parameter[8] = new SqlParameter("@TrangThai", taiKhoanDTO.TrangThai);
            return DataProvider.ExecuteUpdateQuery(query, parameter) == 1;
        }

        public static bool KiemTraTKTonTai(string tenTK)
        {
            string query = "SELECT COUNT(*) FROM tblTaiKhoan WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]) == 1;
        }

        public static string LayMatKhau(string tenTK)
        {
            string query = "SELECT MatKhau FROM tblTaiKhoan WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0].ToString();
        }

        public static string LayHoTen(string tenTK)
        {
            string query = "SELECT HoTen FROM tblTaiKhoan WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0].ToString();
        }

        public static bool SuaMatKhau(string tenTK, string mKMoi)
        {
            string query = "UPDATE tblTaiKhoan SET MatKhau=@MatKhau WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            parameter[1] = new SqlParameter("@MatKhau", mKMoi);
            return DataProvider.ExecuteUpdateQuery(query, parameter) == 1;
        }

        public static bool XoaTK(string tenTK)
        {
            string query = "DELETE FROM tblTaiKhoan WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return DataProvider.ExecuteDeleteQuery(query, parameter) == 1;
        }

        public static bool XoaAnhDaiDien(clsTaiKhoanDTO TaiKhoan)
        {
            string query = "UPDATE tblTaiKhoan SET AnhDaiDien=@AnhDaiDien WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@TenTaiKhoan", TaiKhoan.TenTaiKhoan);
            parameter[1] = new SqlParameter("@AnhDaiDien", TaiKhoan.AnhDaiDien);
            return DataProvider.ExecuteUpdateQuery(query, parameter) == 1;
        }
    }
}
