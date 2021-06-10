using System;
using System.Threading.Tasks;

namespace ProjectWeightLifting.Api.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IExerciseRepository Exercises { get; }
        IMaxRepository Maxes { get; }
        Task<int> CommitAsync();
    }
}