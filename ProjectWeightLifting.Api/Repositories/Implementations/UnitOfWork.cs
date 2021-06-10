using System.Threading.Tasks;
using ProjectWeightLifting.Api.Models.Configurations;
using ProjectWeightLifting.Api.Repositories.Interfaces;

namespace ProjectWeightLifting.Api.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ExerciseRepository _exerciseRepository;
        private MaxRepository _maxRepository;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IExerciseRepository Exercises => _exerciseRepository = _exerciseRepository ?? new ExerciseRepository(_context);
        public IMaxRepository Maxes => _maxRepository = _maxRepository ?? new MaxRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}