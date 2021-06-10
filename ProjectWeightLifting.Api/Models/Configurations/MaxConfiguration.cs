using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectWeightLifting.Api.Models.Configurations
{
    public class MaxConfiguration : IEntityTypeConfiguration<MaxLift>
    {
        public void Configure(EntityTypeBuilder<MaxLift> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Value)
                .IsRequired();
            builder
                .HasOne(m => m.Exercise)
                .WithMany(e => e.MaxLifts)
                .HasForeignKey(m => m.ExerciseId);
            builder
                .Property(m => m.Date)
                .IsRequired();
            builder
                .ToTable("max");
        }
    }
}