using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeightLifting.Api.Models;
using ProjectWeightLifting.Api.Repositories.Interfaces;
using ProjectWeightLifting.Api.Services.Interfaces;

namespace ProjectWeightLifting.Api.Services.Implementations
{
    public class ExerciseService : IExerciseService 
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ExerciseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _unitOfWork.Exercises.GetAllAsync();
        }

        public async Task<Exercise> GetById(int id)
        {
            return await _unitOfWork.Exercises.GetByIdAsync(id);
        }

        public async Task<Exercise> CreateNew(Exercise newExercise)
        {
            await _unitOfWork.Exercises.AddAsync(newExercise);
            await _unitOfWork.CommitAsync();
            return newExercise;
        }

        public async Task<Exercise> Update(Exercise exerciseToBeUpdated, Exercise exercise)
        {
            exerciseToBeUpdated.MaxLifts = exercise.MaxLifts;
            exerciseToBeUpdated.Name = exercise.Name;

            await _unitOfWork.CommitAsync();
            return await GetById(exerciseToBeUpdated.Id);
        }

        public async Task Delete(Exercise entity)
        {
            _unitOfWork.Exercises.Remove(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}