using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsTaiKhoanDTO
    {
        private string tenTaiKhoan;
        private string matKhau;
        private string email;
        private string sDT;
        private string diaChi;
        private string hoTen;
        private bool laAdmin;
        private string anhDaiDien;
        private bool trangThai;

        public clsTaiKhoanDTO()
        {
            LaAdmin = false;
            AnhDaiDien = "profile.png";
            TrangThai = true;
        }

        public string TenTaiKhoan
        {
            get
            {
                return tenTaiKhoan;
            }

            set
            {
                tenTaiKhoan = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string SDT
        {
            get
            {
                return sDT;
            }

            set
            {
                sDT = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string HoTen
        {
            get
            {
                return hoTen;
            }

            set
            {
                hoTen = value;
            }
        }

        public bool LaAdmin
        {
            get
            {
                return laAdmin;
            }

            set
            {
                laAdmin = value;
            }
        }

        public string AnhDaiDien
        {
            get
            {
                return anhDaiDien;
            }

            set
            {
                anhDaiDien = value;
            }
        }

        public bool TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }
    }
}
