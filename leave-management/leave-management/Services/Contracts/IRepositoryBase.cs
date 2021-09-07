using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Services.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class 
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> FindById(int id);
        Task<bool> IsExists(int id);
        Task<bool>Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> Save();
    }
}
