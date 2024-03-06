using AcademifyHub.Entities;

namespace AcademifyHub.Services
{
    public interface IWrittenExamsService
    {
        Task<IEnumerable<WrittenExam>> GetAll(int id = 0);
        Task<WrittenExam> GetById(int id);
        Task<WrittenExam> Add(WrittenExam exam);
        WrittenExam Update(WrittenExam exam);
        WrittenExam Delete(WrittenExam exam);
        public Task<bool> IsvalidGenre(int id);

    }
}
