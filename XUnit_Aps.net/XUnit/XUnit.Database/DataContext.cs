using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  XUnit.Common.Enum;
using XUnit.Database.Schema;
using static XUnit.Common.Enum.Constant;

namespace XUnit.Database
{
    /// <summary>
    /// Điều khiển sự tương tác với cơ sở dữ liệu.
    /// <para>Author: HoangNM</para>
    /// <para>Created: 18/05/2020</para>
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Hàm khởi tạo mặc định
        /// <para>Author: HoangNM</para>
        /// <para>Created: 18/05/2020</para>
        /// </summary>
        public DataContext()
        {
        }
        /// <summary>
        /// Khởi tạo với các tham số cấu hình cho datacontext.
        /// <para>Author: HoangNM</para>
        /// <para>Created: 18/05/2020</para>
        /// </summary>
        /// <param name="options">Các cài đặt cho datacontext</param>
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Cấu hình cho datacontext, chủ yếu chuỗi kết nối.
        /// <para>Author: HoangNM</para>
        /// <para>Created: 18/05/2020</para>
        /// </summary>
        /// <param name="optionsBuilder">Các cài đặt cho datacontext</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConstantCommon.CONNECTION_STRING);
        }

        /// <summary>
        /// Bảng Student
        /// </summary>
        public virtual DbSet<Student> Student { get; set; }

        /// <summary>
        /// Bảng UnitOfStudy
        /// </summary>
        public virtual DbSet<UnitOfStudy> UnitOfStudies { get; set; }
        /// <summary>
        /// Bảng ClassOfStudyUnit
        /// </summary>
        public virtual DbSet<ClassOfStudyUnit> ClassOfStudyUnits { get; set; }
    }
}
