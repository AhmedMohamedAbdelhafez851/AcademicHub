using AcademifyHub.Entities;

namespace AcademifyHub.Services
{
    public interface IOfficesService
    {
        Task<IEnumerable<Office>> GetAll(int id = 0);
        Task<Office> GetById(int id);
        Task<Office> Add(Office office);
        Office Update(Office office);
        Office Delete(Office office);
        public Task<bool> IsvalidGenre(int id);
    }
}
