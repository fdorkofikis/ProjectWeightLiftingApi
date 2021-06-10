using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeightLifting.Api.Models;
using ProjectWeightLifting.Api.Repositories.Interfaces;
using ProjectWeightLifting.Api.Services.Interfaces;

namespace ProjectWeightLifting.Api.Services.Implementations
{
    public class MaxService : IMaxService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public MaxService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<MaxLift>> GetAll()
        {
            return await _unitOfWork.Maxes.GetAllAsync();
        }

        public async Task<MaxLift> GetById(int id)
        {
            return await _unitOfWork.Maxes.GetByIdAsync(id);
        }

        public async Task<MaxLift> CreateNew(MaxLift newEntity)
        {
            await _unitOfWork.Maxes.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            return newEntity;
        }

        public async Task<MaxLift> Update(MaxLift entityToBeUpdated, MaxLift entity)
        {
            entityToBeUpdated.Date = entity.Date;
            entityToBeUpdated.Exercise = entity.Exercise;
            entityToBeUpdated.Value = entity.Value;
            await _unitOfWork.CommitAsync();
            return await GetById(entityToBeUpdated.Id);
        }

        public async Task Delete(MaxLift entity)
        {
            _unitOfWork.Maxes.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<MaxLift>> GetAllLatest()
        {
            return await _unitOfWork.Maxes.GetAllLatest();
        }

        public async Task<IEnumerable<MaxLift>> GetAllBest()
        {
            return await _unitOfWork.Maxes.GetAllBest();
        }

        public async Task<IEnumerable<MaxLift>> GetAllForExercise(Exercise exercise)
        {
            return await _unitOfWork.Maxes.GetAllForExercise(exercise);
        }

        public async Task<MaxLift> GetLatestForExercise(Exercise exercise)
        {
            return await _unitOfWork.Maxes.GetLatestForExercise(exercise);
        }
    }
}