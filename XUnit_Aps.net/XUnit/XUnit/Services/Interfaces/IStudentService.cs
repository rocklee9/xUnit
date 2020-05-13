using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnit_API.Model;

namespace XUnit_API.Services.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAll();
        public Student GetByMssv(string mssv);
        public Student Add(Student student);
        public void Remove(string mssv);

    }
}
