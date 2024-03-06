using AcademifyHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademifyHub.Data.Config
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        void IEntityTypeConfiguration<Exam>.Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.UseTpcMappingStrategy();

            builder.HasOne(x => x.Course)
              .WithOne(x => x.Exam)
              .HasForeignKey<Exam>(x => x.CourseId)
              .IsRequired(false);




        }
    }
}
