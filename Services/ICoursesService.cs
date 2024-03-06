using AcademifyHub.Entities;
namespace AcademifyHub.Services
{
    public interface ICoursesService
    {
        Task<IEnumerable<Course>> GetAll(int id = 0);
        Task<Course> GetById(int id );
        Task<Course> Add(Course course);
        Course Update(Course course);
        Course Delete(Course course);
        public Task<bool> IsvalidGenre(int id); 
    }

}
