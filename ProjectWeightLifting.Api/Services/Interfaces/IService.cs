using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectWeightLifting.Api.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> CreateNew(TEntity newEntity);
        Task<TEntity> Update(TEntity entityToBeUpdated, TEntity entity);
        Task Delete(TEntity entity);
    }
}