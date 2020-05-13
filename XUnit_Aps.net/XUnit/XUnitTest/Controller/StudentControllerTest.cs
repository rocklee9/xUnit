using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using XUnit_API.Controllers;
using XUnit_API.Model;
using XUnit_API.Services.Interfaces;
using XUnitTest.Services;

namespace XUnitTest.Controller
{
    public class StudentControllerTest
    {
        StudentManagementController _controller;
        IStudentService _service;
        public StudentControllerTest()
        {
            _service = new StudentServiceFake();
            _controller = new StudentManagementController(_service);
        }

        // Test get method ===========================================================
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Student>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        // Test GetByMssv method ===========================================================
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get("100");

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Theory]
        [InlineData("101")]
        [InlineData("102")]
        [InlineData("103")]
        [InlineData("104")] //sẽ báo lỗi ở chỗ này vì trong dữ liệu thêm vào không có mã số sinh viên là 104
        public void GetById_ExistingGuidPassed_ReturnsOkResult(string mssv)
        {
            

            // Act
            var okResult = _controller.Get(mssv);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var mssv = "101";

            // Act
            var okResult = _controller.Get(mssv).Result as OkObjectResult;

            // Assert
            Assert.IsType<Student>(okResult.Value);
            Assert.Equal(mssv, (okResult.Value as Student).MSSV);
        }

        // Test Add method ===========================================================

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var student = new Student()
            {
                MSSV = "105",
                Birthday=DateTime.Now
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(student);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var student = new Student()
            {
                MSSV = "105",
                Name = "Nguyễn Văn A",
                Birthday = DateTime.Now
            };

            // Act
            var createdResponse = _controller.Post(student);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var student = new Student()
            {
                MSSV = "105",
                Name = "Nguyễn Văn A",
                Birthday = DateTime.Now
            };

            // Act
            var createdResponse = _controller.Post(student) as CreatedAtActionResult;
            var item = createdResponse.Value as Student;

            // Assert
            Assert.IsType<Student>(item);
            Assert.Equal("Nguyễn Văn A", item.Name);
        }

        // Test Remove method ===========================================================
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            

            // Act
            var badResponse = _controller.Remove("100");

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {
            

            // Act
            var okResponse = _controller.Remove("101");

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            

            // Act
            var okResponse = _controller.Remove("101");

            // Assert
            Assert.Equal(2, _service.GetAll().Count());
        }
    }
}
