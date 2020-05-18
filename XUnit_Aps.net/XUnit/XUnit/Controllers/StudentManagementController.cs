using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using XUnit_API.Models.Dtos.StudentManagement;
using XUnit_API.Models.Services.Interfaces;

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
        public ActionResult<IEnumerable<StudentResponse>> Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<StudentResponse> Get(string mssv)
        {
            return Ok(_service.GetByMssv(mssv));
        }

        [HttpPost]
        public ActionResult<StudentResponse> Post([FromBody] StudentResponse value)
        {
            return StatusCode(201,_service.Create(value));
        }
        [HttpPut]
        public ActionResult<StudentResponse> Put([FromBody] StudentResponse value)
        {
           
            return Ok(_service.Edit(value));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string mssv)
        {

            return Ok(_service.Delete(mssv));
        }
    }
}