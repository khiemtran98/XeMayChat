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
    public class clsHoaDonDAO
    {
        public static int LayMaHDLonNhat()
        {
            try
            {
                string query = "SELECT MAX(MaHD) FROM tblHoaDon";
                SqlParameter[] parameter = new SqlParameter[0];
                return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]);
            }
            catch (InvalidCastException e)
            {
                return 0;
            }
        }

        public static bool ThemHoaDon(clsHoaDonDTO hoaDonDTO)
        {
            string query = "INSERT INTO tblHoaDon (MaHD, TenTaiKhoan, NgayMua, DiaChiGiaoHang, SDTGiaoHang, TongTien, TrangThai) VALUES (@MaHD, @TenTaiKhoan, @NgayMua, @DiaChiGiaoHang, @SDTGiaoHang, @TongTien, @TrangThai)";
            SqlParameter[] parameter = new SqlParameter[7];
            parameter[0] = new SqlParameter("@MaHD", hoaDonDTO.MaHD);
            parameter[1] = new SqlParameter("@TenTaiKhoan", hoaDonDTO.TenTaiKhoan);
            parameter[2] = new SqlParameter("@NgayMua", hoaDonDTO.NgayMua);
            parameter[3] = new SqlParameter("@DiaChiGiaoHang", hoaDonDTO.DiaChiGiaoHang);
            parameter[4] = new SqlParameter("@SDTGiaoHang", hoaDonDTO.SDTGiaoHang);
            parameter[5] = new SqlParameter("@TongTien", hoaDonDTO.TongTien);
            parameter[6] = new SqlParameter("@TrangThai", hoaDonDTO.TrangThai);
            return Convert.ToInt32(DataProvider.ExecuteInsertQuery(query, parameter)) == 1;
        }

        public static bool SuaHoaDon(clsHoaDonDTO hoaDonDTO)
        {
            string query = "UPDATE tblHoaDon SET NgayMua=@NgayMua, DiaChiGiaoHang=@DiaChiGiaoHang, SDTGiaoHang=@SDTGiaoHang, TongTien=@TongTien WHERE MaHD=@MaHD";
            SqlParameter[] parameter = new SqlParameter[5];
            parameter[0] = new SqlParameter("@MaHD", hoaDonDTO.MaHD);
            parameter[1] = new SqlParameter("@NgayMua", hoaDonDTO.NgayMua);
            parameter[2] = new SqlParameter("@DiaChiGiaoHang", hoaDonDTO.DiaChiGiaoHang);
            parameter[3] = new SqlParameter("@SDTGiaoHang", hoaDonDTO.SDTGiaoHang);
            parameter[4] = new SqlParameter("@TongTien", hoaDonDTO.TongTien);
            return Convert.ToInt32(DataProvider.ExecuteUpdateQuery(query, parameter)) == 1;
        }

        public static DataTable LayDSHoaDon()
        {
            string query = "SELECT * FROM tblHoaDon";
            SqlParameter[] parameter = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static DataTable LayLichSuGiaoDich(string tenTK)
        {
            string query = "SELECT * FROM tblHoaDon WHERE TenTaiKhoan=@TenTaiKhoan";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TenTaiKhoan", tenTK);
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static DataRow LayThongTinHD(string maHD)
        {
            string query = "SELECT * FROM tblHoaDon WHERE MaHD=@MaHD";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@MaHD", maHD);
            return DataProvider.ExecuteSelectQuery(query, parameter).Rows[0];
        }

        public static bool XoaHoaDon(clsHoaDonDTO hoaDonDTO)
        {
            string query = "UPDATE tblHoaDon SET TrangThai=@TrangThai WHERE MaHD=@MaHD";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@MaHD", hoaDonDTO.MaHD);
            parameter[1] = new SqlParameter("@TrangThai", hoaDonDTO.TrangThai);
            return Convert.ToInt32(DataProvider.ExecuteUpdateQuery(query, parameter)) == 1;
        }

        public static bool CapNhatTongTienHoaDon(string maHD, int donGia)
        {
            string query = "UPDATE tblHoaDon SET TongTien=TongTien-@DonGia WHERE MaHD=@MaHD";
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = new SqlParameter("@MaHD", maHD);
            parameter[1] = new SqlParameter("@DonGia", donGia);
            return Convert.ToInt32(DataProvider.ExecuteUpdateQuery(query, parameter)) == 1;
        }
    }
}
