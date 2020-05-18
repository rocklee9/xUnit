using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XUnit.Database.Schema
{
    /// <summary>
    /// Bảng Lớp học phần dùng trong hệ thống.
    /// <para>Author: HoangNM</para>
    /// <para>Created: 18/05/2020</para>
    /// </summary>
    [Table("ClassOfStudyUnit")]
    public class ClassOfStudyUnit
    {
        /// <summary>
        /// Id của lớp học phần
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// MSSV của bảng sinh viên
        /// </summary>
        [Required]
        [StringLength(9)]
        public string MSSV { get; set; }


        /// <summary>
        /// Id của học phần
        /// </summary>
       
        public int IdUnitOfStudy { get; set; }
        /// <summary>
        /// Sinh viên thuộc lớp học phần
        /// </summary>

        [ForeignKey("MSSV")]
        public virtual Student Student { get; set; }
        /// <summary>
        /// Học phần trong lớp học phần
        /// </summary>

        [ForeignKey("IdUnitOfStudy")]
        public virtual UnitOfStudy UnitOfStudy { get; set; }

    }
}
