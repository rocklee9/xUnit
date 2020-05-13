using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnit_API.Model;
using XUnit_API.Services.Interfaces;

namespace XUnit_API.Services.Implements
{
    public class StudentService : IStudentService
    {
        public Student Add(Student student)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetByMssv(string mssv)
        {
            throw new NotImplementedException();
        }

        public void Remove(string mssv)
        {
            throw new NotImplementedException();
        }
    }
}
