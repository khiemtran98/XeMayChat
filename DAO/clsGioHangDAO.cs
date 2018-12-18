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
    public class clsGioHangDAO
    {
        public static bool KiemTraCoSanPhamTrongGH(string tenTK)
        {
            string query = "SELECT COUNT(*) FROM tblGioHang WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]) >= 1;
        }

        public static int DemSoLuongSanPhamTrongGH(string tenTK)
        {
            string query = "SELECT SUM(SoLuong) FROM tblGioHang WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]);
        }

        public static DataTable LayGioHang(string tenTK)
        {
            string query = "SELECT gh.MaSP, TenSP, GiaTien, AnhMinhHoa, SoLuong FROM tblGioHang gh INNER JOIN tblSanPham sp ON gh.MaSP=sp.MaSP WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static int TinhTongTien(string tenTK)
        {
            try
            {
                string query = "SELECT SUM(SoLuong * GiaTien) FROM tblGioHang gh INNER JOIN tblSanPham sp ON gh.MaSP=sp.MaSP WHERE TenTaiKhoan=@TenTaiKhoan";
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
                return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]);
            }
            catch (InvalidCastException e)
            {
                return 0;
            }
        }

        public static bool KiemTraSPTonTai(clsGioHangDTO gioHangDTO)
        {
            string query = "SELECT COUNT(*) FROM tblGioHang WHERE TenTaiKhoan=@TenTaiKhoan AND MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@TenTaiKhoan", gioHangDTO.TenTaiKhoan);
            parameter[1] = new SqlParameter("@MaSP", gioHangDTO.MaSP);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]) == 1;
        }

        public static int LaySoLuongSP(clsGioHangDTO gioHangDTO)
        {
            try
            {
                string query = "SELECT SoLuong FROM tblGioHang WHERE TenTaiKhoan=@TenTaiKhoan AND MaSP=@MaSP";
                SqlParameter[] parameter = new SqlParameter[2];
                parameter[0] = new SqlParameter("@TenTaiKhoan", gioHangDTO.TenTaiKhoan);
                parameter[1] = new SqlParameter("@MaSP", gioHangDTO.MaSP);
                return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]);
            }
            catch (IndexOutOfRangeException e)
            {
                return 0;
            }
        }

        public static bool ThemSPVaoGH(clsGioHangDTO gioHangDTO)
        {
            string query = "INSERT INTO tblGioHang (TenTaiKhoan, MaSP, SoLuong) VALUES (@TenTaiKhoan, @MaSP, @SoLuong)";
            SqlParameter[] parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@TenTaiKhoan", gioHangDTO.TenTaiKhoan);
            parameter[1] = new SqlParameter("@MaSP", gioHangDTO.MaSP);
            parameter[2] = new SqlParameter("@SoLuong", gioHangDTO.SoLuong);
            return DataProvider.ExecuteInsertQuery(query, parameter) == 1;
        }

        public static bool CapNhatSoLuongSP(clsGioHangDTO gioHangDTO)
        {
            string query = "UPDATE tblGioHang SET SoLuong=SoLuong+@SoLuong WHERE TenTaiKhoan=@TenTaiKhoan AND MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@TenTaiKhoan", gioHangDTO.TenTaiKhoan);
            parameter[1] = new SqlParameter("@MaSP", gioHangDTO.MaSP);
            parameter[2] = new SqlParameter("@SoLuong", gioHangDTO.SoLuong);
            return DataProvider.ExecuteUpdateQuery(query, parameter) == 1;
        }

        public static bool XoaSP(clsGioHangDTO gioHangDTO)
        {
            string query = "DELETE FROM tblGioHang WHERE TenTaiKhoan=@TenTaiKhoan AND MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@TenTaiKhoan", gioHangDTO.TenTaiKhoan);
            parameter[1] = new SqlParameter("@MaSP", gioHangDTO.MaSP);
            return DataProvider.ExecuteDeleteQuery(query, parameter) == 1;
        }

        public static bool XoaGioHang(string tenTK)
        {
            string query = "DELETE FROM tblGioHang WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return DataProvider.ExecuteDeleteQuery(query, parameter) == 1;
        }
    }
}
