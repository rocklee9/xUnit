using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XUnit.Database.Schema
{
    /// <summary>
    /// Bảng Học phần dùng trong hệ thống.
    /// <para>Author: HoangNM</para>
    /// <para>Created: 18/05/2020</para>
    /// </summary>
    [Table("UnitOfStudy")]
    public class UnitOfStudy
    {
        /// <summary>
        /// Id của học phần
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Tên của học phần
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TenHocPhan { get; set; }

        /// <summary>
        /// Những lớp học phần chứa học phần
        /// </summary>
        public virtual ICollection<ClassOfStudyUnit> ClassOfStudyUnits { get; set; }
    }
}
