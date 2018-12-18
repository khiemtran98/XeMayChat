using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsCTHoaDonDTO
    {
        private string _maHD;
        private string _maSP;
        private int _soLuong;
        private double _donGia;

        public string MaHD { get => _maHD; set => _maHD = value; }
        public string MaSP { get => _maSP; set => _maSP = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public double DonGia { get => _donGia; set => _donGia = value; }
    }
}
