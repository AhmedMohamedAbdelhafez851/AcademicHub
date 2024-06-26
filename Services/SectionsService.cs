using AcademifyHub.Data;
using AcademifyHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademifyHub.Services
{
    public class SectionsService : ISectionsService
    {
        private readonly AppDbContext _context;
        public SectionsService(AppDbContext context)
        {
            _context = context;

        }
        public Task<bool> IsvalidGenre(int id)
        {
            return _context.Sections.AnyAsync(c => c.Id == id);
        }
        public async Task<Section> Add(Section section)

        {
            await _context.Sections.AddAsync(section);
            _context.SaveChanges();
            return section;

        }

        public Section Delete(Section section)
        {

            _context.Remove(section);
            _context.SaveChanges();

            return section;
        }

        public async Task<IEnumerable<Section>> GetAll(int sectionId = 0)
        {
          

            return await _context.Sections
                           .Where(s => s.Id == sectionId || sectionId == 0)
                           .Include(c => c.Course)
                           .Include(i=>i.Instructor)
                           .Include(s=>s.Schedule)                    
                           .ToListAsync();                            
        }

      
        public async Task<Section> GetById(int id)
        {
            var section =  await _context.Sections
                .Include(s => s.Course)
                .Include(s => s.Instructor)
                .Include(s => s.Schedule)
                .SingleOrDefaultAsync(s => s.Id == id);
            if (section == null)
            {
                throw new Exception($"section with ID {id} not found.");
            }
            return section;
        }


        public Section Update(Section section)
        {
            _context.Update(section);
            _context.SaveChanges();

            return section;
        }

    }
}
