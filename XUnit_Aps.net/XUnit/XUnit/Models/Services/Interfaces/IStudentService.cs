using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnit_API.Models.Dtos.StudentManagement;

namespace XUnit_API.Models.Services.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<StudentResponse> GetAll();
        public StudentResponse GetByMssv(string mssv);
        public StudentResponse Create(StudentResponse student);
        public StudentResponse Edit(StudentResponse student);
        public bool Delete(string mssv);
    }
}
