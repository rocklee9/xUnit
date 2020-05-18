using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using XUnit.Database;
using XUnit_API.Models.Dtos.StudentManagement;
using XUnit_API.Models.Services.Implements;
using TblStudent = XUnit.Database.Schema.Student;

namespace XUnitTest.Services.StudentManagement
{
    public class StudentServiceTest
    {
        [Fact]
        public void GetItemsFromCart_WhenCalled_ReturnStudents()
        {
            // Arrange
            
            var StudentService = new StudentService();

            // Act
            var getResults = StudentService.GetAll();
            // Assert

            Assert.Equal(2, getResults.Count());

        }

        [Fact]
        public void GetItemByMssvFromCart_WhenCalled_ReturnStudent()
        {
            // Arrange

            var StudentService = new StudentService();

            // Act
            var result = StudentService.GetByMssv("101");
            // Assert

            Assert.Equal("101", result.MSSV);
            Assert.Equal("Nguyễn Minh Hoàng", result.HoTen);
        }

        //[Fact]
        public void Post_WhenCalled_ReturnStudent()
        {
            // Arrange

            var StudentService = new StudentService();
            var newStudent = new StudentResponse
            {
                MSSV = "103",
                HoTen = "Add New",
                SoDienThoai = "123123",
                GioiTinh = true,
                NgaySinh = DateTime.Now,
                DiaChi = "Đà Nẵng"
            };

            // Act
            var result = StudentService.Create(newStudent);
            var getresults = StudentService.GetAll();
            // Assert

            Assert.Equal("103", result.MSSV);
            Assert.Equal(3, getresults.Count());
        }


        //[Fact]
        public void Put_WhenCalled_ReturnStudent()
        {
            // Arrange

            var StudentService = new StudentService();
            var changeStudent = new StudentResponse
            {
                MSSV = "103",
                HoTen = "Edit",
                SoDienThoai = "123123",
                GioiTinh = true,
                NgaySinh = DateTime.Now,
                DiaChi = "Đà Nẵng"
            };

            // Act
            var result = StudentService.Edit(changeStudent);
            var getResult = StudentService.GetByMssv("103");
            // Assert

            Assert.Equal(changeStudent, result);
            Assert.Equal("Edit", getResult.HoTen);
        }
        //[Fact]
        public void Delete_WhenCalled_ReturnStudent()
        {
            // Arrange
            var StudentService = new StudentService();

            // Act
            var result = StudentService.Delete("103");
            var getResult = StudentService.GetByMssv("103");

            // Assert

            Assert.Equal(true, result);
            Assert.Equal(null, getResult);

        }

       
    }
}
