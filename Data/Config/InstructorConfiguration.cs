using AcademifyHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademifyHub.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
          //  builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.LName)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50).IsRequired();


            builder.HasOne(x => x.Office)
                    .WithOne(x => x.Instructor)
                    .HasForeignKey<Instructor>(x => x.OfficeId);

            builder.HasMany(i => i.Sections)
       .WithOne(s => s.Instructor)
       .HasForeignKey(s => s.InstructorId)
       .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(i => i.Office)
           .WithOne(o => o.Instructor)
           .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Offices");
            builder.ToTable("Instructors");
        }
    }
}
