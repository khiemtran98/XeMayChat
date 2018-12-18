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
    public class clsSanPhamDAO
    {
        public static DataTable LayDSSanPham_AdminCP()
        {
            string query = "SELECT * FROM tblSanPham";
            SqlParameter[] parameter = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static DataTable LayDSSanPhamTheoLoai_AdminCP(string maLoaiSP)
        {
            string query = "SELECT * FROM tblSanPham WHERE MaLoaiSP=@MaLoaiSP";
            if (maLoaiSP != "blank")
            {
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@MaLoaiSP", maLoaiSP);
                return DataProvider.ExecuteSelectQuery(query, parameter);

            }
            else
            {
                query = "SELECT * FROM tblSanPham";
                SqlParameter[] parameter = new SqlParameter[0];
                return DataProvider.ExecuteSelectQuery(query, parameter);
            }
        }

        public static DataRow LaySanPham(string maSP)
        {
            string query = "SELECT * FROM tblSanPham WHERE MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@MaSP", maSP);
            return DataProvider.ExecuteSelectQuery(query, parameter).Rows[0];
        }

        public static bool KiemTraSPTonTai(string maSP)
        {
            string query = "SELECT COUNT(*) FROM tblSanPham WHERE MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@MaSP", maSP);
            return Convert.ToInt32(DataProvider.ExecuteSelectQuery(query, parameter).Rows[0][0]) == 1;
        }

        public static bool ThemSanPham(clsSanPhamDTO SanPham)
        {
            string query = "INSERT INTO tblSanPham(MaSP, TenSP, ThongTin, GiaTien, SoLuongTonKho, MaLoaiSP, AnhMinhHoa, TrangThai) VALUES (@MaSP, @TenSP, @ThongTin, @GiaTien, @SoLuongTonKho, @MaLoaiSP, @AnhMinhHoa, @TrangThai)";
            SqlParameter[] parameter = new SqlParameter[8];
            parameter[0] = new SqlParameter("@MaSP", SanPham.MaSP);
            parameter[1] = new SqlParameter("@TenSP", SanPham.TenSP);
            parameter[2] = new SqlParameter("@ThongTin", SanPham.ThongTin);
            parameter[3] = new SqlParameter("@GiaTien", SanPham.GiaTien);
            parameter[4] = new SqlParameter("@SoLuongTonKho", SanPham.SoLuongTonKho);
            parameter[5] = new SqlParameter("@MaLoaiSP", SanPham.MaLoaiSP);
            parameter[6] = new SqlParameter("@AnhMinhHoa", SanPham.AnhMinhHoa);
            parameter[7] = new SqlParameter("@TrangThai", SanPham.TrangThai);
            return DataProvider.ExecuteInsertQuery(query, parameter) == 1;
        }

        public static bool SuaSanPham(clsSanPhamDTO SanPham)
        {
            string query = "UPDATE tblSanPham SET TenSP=@TenSP, ThongTin=@ThongTin, GiaTien=@GiaTien, SoLuongTonKho=@SoLuongTonKho, MaLoaiSP=@MaLoaiSP, AnhMinhHoa=@AnhMinhHoa, TrangThai=@TrangThai WHERE MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[8];
            parameter[0] = new SqlParameter("@MaSP", SanPham.MaSP);
            parameter[1] = new SqlParameter("@TenSP", SanPham.TenSP);
            parameter[2] = new SqlParameter("@ThongTin", SanPham.ThongTin);
            parameter[3] = new SqlParameter("@GiaTien", SanPham.GiaTien);
            parameter[4] = new SqlParameter("@SoLuongTonKho", SanPham.SoLuongTonKho);
            parameter[5] = new SqlParameter("@MaLoaiSP", SanPham.MaLoaiSP);
            parameter[6] = new SqlParameter("@AnhMinhHoa", SanPham.AnhMinhHoa);
            parameter[7] = new SqlParameter("@TrangThai", SanPham.TrangThai);
            return DataProvider.ExecuteUpdateQuery(query, parameter) == 1;
        }

        public static bool XoaSanPham(string maSP)
        {
            string query = "DELETE FROM tblSanPham WHERE MaSP=@MaSP";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@MaSP", maSP);
            return DataProvider.ExecuteDeleteQuery(query, parameter) == 1;
        }

        public static DataTable LayDSSanPham()
        {
            string query = "SELECT * FROM tblSanPham WHERE TrangThai=1";
            SqlParameter[] parameter = new SqlParameter[0];
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }

        public static DataTable LayDSSanPhamTheoLoai(string maLoaiSP)
        {
            string query = "SELECT * FROM tblSanPham WHERE MaLoaiSP=@MaLoaiSP AND TrangThai=1";
            if (maLoaiSP != "blank")
            {
                SqlParameter[] parameter = new SqlParameter[1];
                parameter[0] = new SqlParameter("@MaLoaiSP", maLoaiSP);
                return DataProvider.ExecuteSelectQuery(query, parameter);

            }
            else
            {
                query = "SELECT * FROM tblSanPham WHERE TrangThai=1";
                SqlParameter[] parameter = new SqlParameter[0];
                return DataProvider.ExecuteSelectQuery(query, parameter);
            }
        }

        public static DataTable TimKiemSanPham(string tuKhoa)
        {
            string query = "SELECT * FROM tblSanPham WHERE TenSP LIKE '%%'+@TuKhoa+'%%' AND TrangThai=1";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@TuKhoa", tuKhoa);
            return DataProvider.ExecuteSelectQuery(query, parameter);
        }
    }
}
