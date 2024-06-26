using AcademifyHub.Data;
using AcademifyHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademifyHub.Services
{
    public class InstructorsService  : IInstructorsService  
    {
        private readonly AppDbContext _context;
        public InstructorsService(AppDbContext context)
        {
            _context = context;

        }
        public Task<bool> IsvalidGenre(int id)
        {
            return _context.Instructors.AnyAsync(c => c.Id == id);
        }
        public async Task<Instructor> Add(Instructor instructor)
        {
            await _context.Instructors.AddAsync(instructor);
            _context.SaveChanges();
            return instructor;

        }

        public Instructor Delete(Instructor instructor)
        {
         
        _context.Instructors.Remove(instructor);
            _context.SaveChanges();

            return instructor;
        }


        public async Task<IEnumerable<Instructor>> GetAll(int InstructorId = 0)
        {
           

            return await _context.Instructors.Include(i=>i.Office).ToListAsync();
        }

        public async Task<Instructor> GetById(int id)
        {
            var instructor = await _context.Instructors.Include(i=>i.Office).SingleOrDefaultAsync(c => c.Id == id);
            if (instructor == null)
            {
                throw new Exception($"instructor with ID {id} not found.");
            }
            return instructor;
        }


        public Instructor Update(Instructor instructor)
        {
            _context.Update(instructor);
            _context.SaveChanges();

            return instructor;
        }

       
    }
}
