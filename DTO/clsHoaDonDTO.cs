using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsHoaDonDTO
    {
        private string maHD;
        private string tenTaiKhoan;
        private DateTime ngayMua;
        private string diaChiGiaoHang;
        private string sDTGiaoHang;
        private double tongTien;
        private bool trangThai;

        public string MaHD { get => maHD; set => maHD = value; }
        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
        public string DiaChiGiaoHang { get => diaChiGiaoHang; set => diaChiGiaoHang = value; }
        public string SDTGiaoHang { get => sDTGiaoHang; set => sDTGiaoHang = value; }
        public double TongTien { get => tongTien; set => tongTien = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
