using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnit_API.Controllers;
using XUnit_API.Models.Dtos.StudentManagement;
using XUnit_API.Models.Services.Interfaces;

namespace XUnitTest.Controller.StudentManagement
{
    public class StudentManagementControllerTest
    {
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult_WithStudent()
        {
            // Arrange
            var listStudent = new List<StudentResponse>();
            listStudent.Add(new StudentResponse
            {
                MSSV = "101",
                HoTen = "Hoang",
                SoDienThoai = "123123",
                GioiTinh = true,
                NgaySinh = DateTime.Now,
                DiaChi = "Đà Nẵng"
            });
            listStudent.Add(new StudentResponse
            {
                MSSV = "102",
                HoTen = "Nam",
                SoDienThoai = "321321",
                GioiTinh = true,
                NgaySinh = DateTime.Now,
                DiaChi = "Đà Nẵng"
            });
            listStudent.Add(new StudentResponse
            {
                MSSV = "103",
                HoTen = "Việt",
                SoDienThoai = "444444",
                GioiTinh = true,
                NgaySinh = DateTime.Now,
                DiaChi = "Đà Nẵng"
            });

            var serviceMock = new Mock<IStudentService>();
            serviceMock.Setup(mock => mock.GetAll()).Returns(listStudent);
            var controller = new StudentManagementController(serviceMock.Object);

            // Act
            var getResults = controller.Get();

            var result = getResults.Result as OkObjectResult;
            var data = Assert.IsType<List<StudentResponse>>(result.Value);
            // Assert

            Assert.IsType<OkObjectResult>(getResults.Result);
            Assert.Equal(listStudent, data);
        }

        [Fact]
        public void GetByMSSV_WhenCalled_ReturnsOkResult_WithStudent()
        {
            // Arrange
            var student = new StudentResponse
            {
                MSSV = "101",
                HoTen = "Hoang",
                SoDienThoai = "123123",
                GioiTinh = true,
                NgaySinh = DateTime.Now,
                DiaChi = "Đà Nẵng"
            };
            
            var serviceMock = new Mock<IStudentService>();
            serviceMock.Setup(mock => mock.GetByMssv(It.IsAny<string>())).Returns(student);
            var controller = new StudentManagementController(serviceMock.Object);

            // Act
            var getResults = controller.Get("101");

            var result = getResults.Result as OkObjectResult;
            var item = Assert.IsType<StudentResponse>(result.Value);
            // Assert
            Assert.IsType<OkObjectResult>(getResults.Result);
            Assert.Equal(student, item);
        }

        [Fact]
        public void Post_WhenCalled_Returns201StatusCode_WithStudent()
        {
            // Arrange
            var newStudent = new StudentResponse
            {
                MSSV = "101",
                HoTen = "Hoang",
                SoDienThoai = "123123",
                GioiTinh = true,
                NgaySinh = DateTime.Now,
                DiaChi = "Đà Nẵng"
            };

            var serviceMock = new Mock<IStudentService>();
            serviceMock.Setup(mock => mock.Create(It.IsAny<StudentResponse>())).Returns(newStudent);
            var controller = new StudentManagementController(serviceMock.Object);

            // Act
            var results = controller.Post(newStudent);

            var result = results.Result as ObjectResult;
            var resultItem = Assert.IsType<StudentResponse>(result.Value);

            // Assert

            Assert.IsType<ObjectResult>(results.Result);
            Assert.Equal(newStudent, resultItem);
            Assert.Equal(201, result.StatusCode);

        }

        [Fact]
        public void Put_WhenCalled_Returns200StatusCode()
        {
            // Arrange
            var updateStudent = new StudentResponse
            {
                MSSV = "101",
                HoTen = "Hoang",
                SoDienThoai = "123123",
                GioiTinh = true,
                NgaySinh = DateTime.Now,
                DiaChi = "Đà Nẵng"
            };

            var serviceMock = new Mock<IStudentService>();
            serviceMock.Setup(mock => mock.Edit(It.IsAny<StudentResponse>())).Returns(updateStudent);
            var controller = new StudentManagementController(serviceMock.Object);

            // Act
            var results = controller.Put(updateStudent);

            var result = results.Result as ObjectResult;
            var resultItem = Assert.IsType<StudentResponse>(result.Value);

            // Assert

            Assert.Equal(updateStudent, resultItem);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Delete_WhenCalled_Returns200StatusCode()
        {
            // Arrange
            string mssv = "101";

            var serviceMock = new Mock<IStudentService>();
            serviceMock.Setup(mock => mock.Delete(It.IsAny<string>())).Returns(true);
            var controller = new StudentManagementController(serviceMock.Object);

            // Act
            var results = controller.Delete(mssv);

            var result = results.Result as ObjectResult;
            var resultItem = Assert.IsType<bool>(result.Value);

            // Assert

            Assert.Equal(200, result.StatusCode);
        }
    }
}
