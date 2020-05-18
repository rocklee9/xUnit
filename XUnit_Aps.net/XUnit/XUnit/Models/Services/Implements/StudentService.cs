using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnit.Database;
using XUnit.Database.Schema;
using XUnit_API.Models.Dtos.StudentManagement;
using XUnit_API.Models.Services.Interfaces;
using TblStudent = XUnit.Database.Schema.Student;

namespace XUnit_API.Models.Services.Implements
{
    public class StudentService : IStudentService
    {
        private DataContext context ;
        public StudentService()
        {
            context = new DataContext();
        }
        public StudentResponse Create(StudentResponse student)
        {
            TblStudent newStudent = new TblStudent
            {
                MSSV = student.MSSV,
                HoTen = student.HoTen,
                SoDienThoai = student.SoDienThoai,
                GioiTinh = student.GioiTinh,
                NgaySinh = student.NgaySinh,
                DiaChi = student.DiaChi

            };
            context.Student.Add(newStudent);
            context.SaveChanges();
            return student;
        }

        public bool Delete(string mssv)
        {
            var student = context.Student.FirstOrDefault(x => x.MSSV == mssv);
            if (student == null)
            {
                return false;
            }
            else
            {
                context.Remove(student);
            }
           
            context.SaveChanges();
            return true;
        }

        public StudentResponse Edit(StudentResponse student)
        {
            var studentOld = context.Student.Where(x => x.MSSV == student.MSSV).FirstOrDefault();
            studentOld.HoTen = student.HoTen;
            studentOld.SoDienThoai = student.SoDienThoai;
            studentOld.GioiTinh = student.GioiTinh;
            studentOld.NgaySinh = student.NgaySinh;
            studentOld.DiaChi = student.DiaChi;

            context.SaveChanges();
            return student;
        }

        public IEnumerable<StudentResponse> GetAll()
        {
            return context.Student.Select(x => new StudentResponse
            {
                MSSV = x.MSSV,
                HoTen = x.HoTen,
                SoDienThoai = x.SoDienThoai,
                GioiTinh = x.GioiTinh,
                NgaySinh = x.NgaySinh,
                DiaChi = x.DiaChi
            }).ToList();
        }

        public StudentResponse GetByMssv(string mssv)
        {
            return context.Student.Where(x=>x.MSSV==mssv).Select(x => new StudentResponse
            {
                MSSV = x.MSSV,
                HoTen = x.HoTen,
                SoDienThoai = x.SoDienThoai,
                GioiTinh = x.GioiTinh,
                NgaySinh = x.NgaySinh,
                DiaChi = x.DiaChi
            }).FirstOrDefault();
        }
    }
}
