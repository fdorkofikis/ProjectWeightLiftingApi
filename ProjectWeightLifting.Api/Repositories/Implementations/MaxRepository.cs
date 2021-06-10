using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectWeightLifting.Api.Models;
using ProjectWeightLifting.Api.Models.Configurations;
using ProjectWeightLifting.Api.Repositories.Interfaces;

namespace ProjectWeightLifting.Api.Repositories.Implementations
{
    public class MaxRepository : Repository<MaxLift>, IMaxRepository
    {
        public MaxRepository(AppDbContext context) : base(context) { }

        public new async Task<IEnumerable<MaxLift>> GetAllAsync()
        {
            return  await Context.Maxes
                .Include(m => m.Exercise)
                .ToListAsync();
        }
        
        public new async ValueTask<MaxLift> GetByIdAsync(int id)
        {
            return await Context.Maxes
                .Include(m => m.Exercise)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<MaxLift>> GetAllLatest()
        {
            return await Context.Maxes
                .Select(m => m.ExerciseId)
                .Distinct()
                .SelectMany(e => Context.Maxes.Where(m => m.ExerciseId == e).OrderByDescending(m => m.Date).Take(1))
                .ToListAsync();
        }

        public async Task<IEnumerable<MaxLift>> GetAllBest()
        {
            return await Context.Maxes
                .Select(m => m.ExerciseId)
                .Distinct()
                .SelectMany(e => Context.Maxes.Where(m => m.ExerciseId == e).OrderByDescending(m => m.Value).Take(1))
                .ToListAsync();
        }

        public async Task<IEnumerable<MaxLift>> GetAllForExercise(Exercise exercise)
        {
            return await Context.Maxes
                .Where(m =>m.Exercise.Equals(exercise))
                .ToListAsync();
        }

        public async Task<MaxLift> GetLatestForExercise(Exercise exercise)
        {
            return await Context.Maxes
                .Where(m => m.Exercise.Equals(exercise))
                .OrderByDescending(m => m.Date)
                .FirstAsync();
        }
    }
}