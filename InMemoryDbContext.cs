using AcademifyHub.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadimfyHub.Tests
{
    internal class InMemoryDbContext :  AppDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString()); 
        }

        public override void Dispose()
        {
            Database.EnsureDeleted();   
            base.Dispose();
        }
    }
}
