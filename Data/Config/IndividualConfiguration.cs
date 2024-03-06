using AcademifyHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademifyHub.Data.Config
{
    internal class IndividualConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder.ToTable("Individuals");
        }
    }
}
