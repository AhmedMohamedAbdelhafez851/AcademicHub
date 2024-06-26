using AcademifyHub.Data;
using AcademifyHub.Entities;
using AcademifyHub.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AcademifyHub.Tests
{
    public class CoursesServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public CoursesServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task AddCourse_AddsCourseToDatabase()
        {
            // Arrange
            using var context = new AppDbContext(_dbContextOptions);
            var service = new CoursesService(context);
            var course = new Course { CourseName = "New Course", Price = 100, HoursToComplete = 10 };

            // Act
            var addedCourse = await service.Add(course);

            // Assert
            var courseInDb = await context.Courses.FindAsync(addedCourse.Id);
            Assert.NotNull(courseInDb);
            Assert.Equal(course.CourseName, courseInDb.CourseName);
        }

        [Fact]
        public async Task DeleteCourse_RemovesCourseFromDatabase()
        {
            // Arrange
            using var context = new AppDbContext(_dbContextOptions);
            var service = new CoursesService(context);
            var course = new Course { CourseName = "Course to Delete", Price = 100, HoursToComplete = 10 };
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            // Act
            var deletedCourse = service.Delete(course);

            // Assert
            var courseInDb = await context.Courses.FindAsync(course.Id);
            Assert.Null(courseInDb);
        }

        [Fact]
        public async Task GetAllCourses_ReturnsAllCourses()
        {
            // Arrange
            using var context = new AppDbContext(_dbContextOptions);
            var service = new CoursesService(context);

            // Clear existing data
            context.Courses.RemoveRange(context.Courses);
            await context.SaveChangesAsync();

            var courses = new List<Course>
            {
                new Course { CourseName = "Course 1", Price = 100, HoursToComplete = 10 },
                new Course { CourseName = "Course 2", Price = 200, HoursToComplete = 20 }
            };
            context.Courses.AddRange(courses);
            await context.SaveChangesAsync();

            // Act
            var result = await service.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetById_ReturnsCourse_WhenCourseExists()
        {
            // Arrange
            using var context = new AppDbContext(_dbContextOptions);
            var service = new CoursesService(context);
            var course = new Course { CourseName = "Existing Course", Price = 100, HoursToComplete = 10 };
            context.Courses.Add(course);
            await context.SaveChangesAsync();

            // Act
            var result = await service.GetById(course.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(course.CourseName, result.CourseName);
        }

        [Fact]
        public async Task UpdateCourse_UpdatesCourseInDatabase()
        {
            // Arrange
            using var context = new AppDbContext(_dbContextOptions);
            var service = new CoursesService(context);
            var course = new Course { CourseName = "Old Course", Price = 100, HoursToComplete = 10 };
            context.Courses.Add(course);
            await context.SaveChangesAsync();
            course.CourseName = "Updated Course";

            // Act
            var updatedCourse = service.Update(course);

            // Assert
            var courseInDb = await context.Courses.FindAsync(course.Id);
            Assert.NotNull(courseInDb);
            Assert.Equal(course.CourseName, courseInDb.CourseName);
        }
    }
}
