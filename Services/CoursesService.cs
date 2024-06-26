using AcademifyHub.Data;
using AcademifyHub.Entities;
using Microsoft.EntityFrameworkCore;
namespace AcademifyHub.Services
{
   public class CoursesService : ICoursesService
    {
        private readonly AppDbContext _context; 
        public CoursesService(AppDbContext context)
        {
            _context = context; 
            
        }
        public Task<bool> IsvalidGenre(int id)
        {
            return _context.Courses.AnyAsync(c => c.Id == id);
        }
        public async Task<Course> Add(Course course)
        {
          await  _context.Courses.AddAsync(course);
            _context.SaveChanges(); 
            return course;

        }

        public  Course Delete(Course course)
        {

            _context.Remove(course);
            _context.SaveChanges();

            return course;
        }

        public async Task<IEnumerable<Course>> GetAll(int courseId = 0)
        {
          
            return await _context.Courses.ToListAsync(); 
        }

        public async Task<Course> GetById(int id)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == id);
            if (course == null)
            {
                throw new Exception($"Course with ID {id} not found.");
            }
            return course;
        }


        public Course Update(Course course)
        {
            _context.Update(course);
            _context.SaveChanges();

            return course;
        }
    }

}
