using AcademifyHub.Data;
using AcademifyHub.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcademifyHub.Services
{
    public class ExamsService : IWrittenExamsService
    {
       
        private readonly AppDbContext _context;
        public ExamsService(AppDbContext context)
        {
            _context = context;

        }
        public Task<bool> IsvalidGenre(int id)
        {
            return _context.WrittenExams.AnyAsync(c => c.Id == id);
        }
        public async Task<WrittenExam> Add(WrittenExam exam)
        {
            await _context.WrittenExams.AddAsync(exam);
            _context.SaveChanges();
            return exam;

        }
        public async Task<IEnumerable<WrittenExam>> GetAll(int examId = 0)
        {
         

            return await _context.WrittenExams.Include(c=>c.Course).ToListAsync();
        }

        public async Task<WrittenExam> GetById(int id)
        {
            var exam = await _context.WrittenExams.Include(c=>c.Course).SingleOrDefaultAsync(c => c.Id == id);
            if (exam == null)
            {
                throw new Exception($" exam with ID {id} not found.");
            }
            return exam;
        }


        public WrittenExam Update(WrittenExam exam)
        {
            _context.Update(exam);
            _context.SaveChanges();

            return exam;
        }


        public WrittenExam Delete(WrittenExam exam)
        {

            _context.Remove(exam);
            _context.SaveChanges();

            return exam;
        }
    }
}