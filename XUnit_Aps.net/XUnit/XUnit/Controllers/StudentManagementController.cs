using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XUnit_API.Model;
using XUnit_API.Services.Interfaces;

namespace XUnit_API.Controllers
{
    /// <summary>
    /// Controller dùng để quản lý sinh viên
    /// <para>Author: HoangNM</para>
    /// <para>Created: 13/05/2020</para>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagementController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentManagementController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var students = _service.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(string mssv)
        {
            var student = _service.GetByMssv(mssv);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Student value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _service.Add(value);
            return CreatedAtAction("Get", new { mssv = student.MSSV }, student);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(string mssv)
        {
            var existingItem = _service.GetByMssv(mssv);

            if (existingItem == null)
            {
                return NotFound();
            }

            _service.Remove(mssv);
            return Ok();
        }
    }
}