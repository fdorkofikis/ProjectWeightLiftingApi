using Microsoft.EntityFrameworkCore;

namespace ProjectWeightLifting.Api.Models.Configurations
{
    public class AppDbContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MaxLift> Maxes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ExerciseConfiguration());
            builder
                .ApplyConfiguration(new MaxConfiguration());
        }
    }
}