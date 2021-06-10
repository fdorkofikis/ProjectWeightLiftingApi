using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeightLifting.Api.Models;

namespace ProjectWeightLifting.Api.Repositories.Interfaces
{
    public interface IMaxRepository : IRepository<MaxLift>
    {
        Task<IEnumerable<MaxLift>> GetAllLatest();
        Task<IEnumerable<MaxLift>> GetAllBest();
        Task<IEnumerable<MaxLift>> GetAllForExercise(Exercise exercise);
        Task<MaxLift> GetLatestForExercise(Exercise exercise);
    }
}