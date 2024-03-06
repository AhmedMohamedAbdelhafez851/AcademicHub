using AcademifyHub.Entities;

namespace AcademifyHub.Services
{
    public interface IInstructorsService 
    {
        Task<IEnumerable<Instructor>> GetAll(int id = 0);
        Task<Instructor> GetById(int id);
        Task<Instructor> Add(Instructor instructor);
        Instructor Update(Instructor instructor);
        Instructor Delete(Instructor instructor);
        public Task<bool> IsvalidGenre(int id);
    }
}
