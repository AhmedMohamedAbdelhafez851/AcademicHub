using AcademifyHub.Controllers;
using AcademifyHub.Data;
using AcademifyHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademifyHub.Services
{
    public class OfficesService : IOfficesService
    {
        private readonly AppDbContext _context;
        public OfficesService(AppDbContext context)
        {
            _context = context;

        }
        public Task<bool> IsvalidGenre(int id)
        {
            return _context.Offices.AnyAsync(c => c.Id == id);
        }
        public async Task<Office> Add(Office office)
        {
            await _context.Offices.AddAsync(office);
            _context.SaveChanges();
            return office;

        }

        public Office Delete(Office office)
        {

            _context.Remove(office);
            _context.SaveChanges();

            return office;
        }

        public async Task<IEnumerable<Office>> GetAll(int officeId = 0)
        {
           

            return await _context.Offices.ToListAsync();
        }

        public async Task<Office> GetById(int id)
        {
            var office = await _context.Offices.Include(i=>i.Instructor).SingleOrDefaultAsync(c => c.Id == id);
            if (office == null)
            {
                throw new Exception($"office with ID {id} not found.");
            }
            return office;
        }


        public Office Update(Office office)
        {
            _context.Update(office);
            _context.SaveChanges();

            return office;
        }
    }
}
