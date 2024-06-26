using AcademifyHub.Controllers;
using AcademifyHub.Entities;
using AcademifyHub.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AcademifyHub.Tests
{
    public class CoursesControllerTests
    {
        private readonly Mock<ICoursesService> _mockService;
        private readonly CoursesController _controller;

        public CoursesControllerTests()
        {
            _mockService = new Mock<ICoursesService>();
            _controller = new CoursesController(_mockService.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult_WhenCourseExists()
        {
            // Arrange
            var courseId = 1;
            var course = new Course { Id = courseId, CourseName = "Course 1", Price = 100, HoursToComplete = 10 };
            _mockService.Setup(service => service.GetById(courseId)).ReturnsAsync(course);

            // Act
            var result = await _controller.GetByIdAsync(courseId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Course>(okResult.Value);
            Assert.Equal(courseId, returnValue.Id);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFoundResult_WhenCourseDoesNotExist()
        {
            // Arrange
            var courseId = 1;
            _mockService.Setup(service => service.GetById(courseId)).ReturnsAsync((Course)null);

            // Act
            var result = await _controller.GetByIdAsync(courseId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreatedCourse()
        {
            // Arrange
            var course = new Course { Id = 1, CourseName = "New Course", Price = 150, HoursToComplete = 20 };
            _mockService.Setup(service => service.Add(course)).ReturnsAsync(course);

            // Act
            var result = await _controller.Create(course);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Course>(okResult.Value);
            Assert.Equal(course.Id, returnValue.Id);
        }

        [Fact]
        public async Task GetAllCourses_ReturnsOkResult_WithListOfCourses()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course { Id = 1, CourseName = "Course 1", Price = 100, HoursToComplete = 10 },
                new Course { Id = 2, CourseName = "Course 2", Price = 200, HoursToComplete = 20 }
            };
            _mockService.Setup(service => service.GetAll(It.IsAny<int>())).ReturnsAsync(courses);

            // Act
            var result = await _controller.GetAllCourses();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Course>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsOkResult_WhenCourseIsUpdated()
        {
            // Arrange
            var courseId = 1;
            var existingCourse = new Course { Id = courseId, CourseName = "Existing Course", Price = 100, HoursToComplete = 10 };
            var updatedCourse = new Course { Id = courseId, CourseName = "Updated Course", Price = 150, HoursToComplete = 20 };

            _mockService.Setup(service => service.GetById(courseId)).ReturnsAsync(existingCourse);
            _mockService.Setup(service => service.IsvalidGenre(courseId)).ReturnsAsync(true);
            _mockService.Setup(service => service.Update(existingCourse)).Returns(updatedCourse);

            // Act
            var result = await _controller.UpdateAsync(courseId, updatedCourse);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Course>(okResult.Value);
            Assert.Equal(updatedCourse.CourseName, returnValue.CourseName);
        }

        [Fact]
        public async Task DeleteAsync_ReturnsOkResult_WhenCourseIsDeleted()
        {
            // Arrange
            var courseId = 1;
            var course = new Course { Id = courseId, CourseName = "Course to Delete", Price = 100, HoursToComplete = 10 };
            _mockService.Setup(service => service.GetById(courseId)).ReturnsAsync(course);
            _mockService.Setup(service => service.Delete(course)).Returns(course);

            // Act
            var result = await _controller.DeleteAsync(courseId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Course>(okResult.Value);
            Assert.Equal(courseId, returnValue.Id);
        }
    }
}
