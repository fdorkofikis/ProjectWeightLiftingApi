﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectWeightLifting.Api.Models.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .HasKey(e => e.Id);
            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .ToTable("exercise");
        }
    }
}