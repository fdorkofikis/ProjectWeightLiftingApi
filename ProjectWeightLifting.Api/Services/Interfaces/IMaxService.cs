using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeightLifting.Api.Models;

namespace ProjectWeightLifting.Api.Services.Interfaces
{
    public interface IMaxService : IService<MaxLift>
    {
        Task<IEnumerable<MaxLift>> GetAllLatest();
        Task<IEnumerable<MaxLift>> GetAllBest();
        Task<IEnumerable<MaxLift>> GetAllForExercise(Exercise exercise);
        Task<MaxLift> GetLatestForExercise(Exercise exercise);
    }
}