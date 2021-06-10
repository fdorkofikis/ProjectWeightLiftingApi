using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectWeightLifting.Api.Models;
using ProjectWeightLifting.Api.Models.Configurations;
using ProjectWeightLifting.Api.Repositories.Interfaces;

namespace ProjectWeightLifting.Api.Repositories.Implementations
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext context) : base(context) {}
        
        public new async ValueTask<Exercise> GetByIdAsync(int id)
        {
            return await Context.Exercises
                .Include(e => e.MaxLifts)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public new async Task<IEnumerable<Exercise>> GetAllAsync()
        {
            return  await Context.Exercises
                .Include(e => e.MaxLifts)
                .ToListAsync();
        }
    }
}