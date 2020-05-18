using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XUnit_API.Models.Dtos.StudentManagement
{
    public class StudentResponse
    {
        /// <summary>
        /// MSSV của bảng sinh viên
        /// </summary>
        public string MSSV { get; set; }

        /// <summary>
        /// Họ tên của sinh viên
        /// </summary>
        public string HoTen { get; set; }

        /// <summary>
        /// Giới tính của sinh viên
        /// </summary>
        public bool GioiTinh { get; set; }

        /// <summary>
        /// Ngày sinh của sinh viên
        /// </summary>
        public DateTime? NgaySinh { get; set; }

        /// <summary>
        /// Họ tên của sinh viên
        /// </summary>
        public string DiaChi { get; set; }

        /// <summary>
        /// Họ tên của sinh viên
        /// </summary>
        public string SoDienThoai { get; set; }
    }
}
