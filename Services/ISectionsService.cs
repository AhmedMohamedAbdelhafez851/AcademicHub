using AcademifyHub.Entities;

namespace AcademifyHub.Services
{
    public interface ISectionsService
    {

        Task<IEnumerable<Section>> GetAll(int id = 0);
        Task<Section> GetById(int id);
        Task<Section> Add(Section section);
        Section Update(Section section);
        Section Delete(Section section);
        public Task<bool> IsvalidGenre(int id);
    }
}
