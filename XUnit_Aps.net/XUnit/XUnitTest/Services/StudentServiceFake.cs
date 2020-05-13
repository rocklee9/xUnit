using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XUnit_API.Model;
using XUnit_API.Services.Interfaces;

namespace XUnitTest.Services
{
    public class StudentServiceFake : IStudentService
    {
        private readonly List<Student> _student;

        public StudentServiceFake()
        {
            _student = new List<Student>()
            {
                new Student() { MSSV = "101",Name = "Nguyễn Minh Hoàng", Birthday=DateTime.Now },
                new Student() { MSSV = "102",Name = "Nguyễn Minh Nam", Birthday=DateTime.Now },
                new Student() { MSSV = "103",Name = "Nguyễn Minh Trung", Birthday=DateTime.Now }
            };
        }
        public Student Add(Student student)
        {
            _student.Add(student);
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _student;
        }

        public Student GetByMssv(string mssv)
        {
            return _student.Where(a => a.MSSV == mssv).FirstOrDefault();
        }

        public void Remove(string mssv)
        {
            var existing = _student.First(a => a.MSSV == mssv);
            _student.Remove(existing);
        }
    }
}
