using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XUnit.Database.Schema
{
    /// <summary>
    /// Bảng sinh viên dùng trong hệ thống.
    /// <para>Author: HoangNM</para>
    /// <para>Created: 18/05/2020</para>
    /// </summary>
    [Table("Student")]
    public class Student
    {
        /// <summary>
        /// Khởi tạo đối tượng cho các khóa ngoại
        /// </summary>
        public Student()
        {
            
        }
        /// <summary>
        /// MSSV của bảng sinh viên
        /// </summary>
        [Key]
        [Required]
        [StringLength(9)]
        public string MSSV { get; set; }
        /// <summary>
        /// Họ tên của sinh viên
        /// </summary>
        [Required]
        [StringLength(50)]
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
        [StringLength(250)]
        public string DiaChi { get; set; }
        /// <summary>
        /// Họ tên của sinh viên
        /// </summary>
        [StringLength(15)]
        public string SoDienThoai { get; set; }

        /// <summary>
        /// Lớp học phần
        /// </summary>
        public virtual ICollection<ClassOfStudyUnit> ClassOfStudyUnits { get; set; }
    }
}
