using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medicion.Datos.Repositorio.Core
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        Task<TEntity> InsertAsync(TEntity Entidad);
        Task<List<TEntity>> InsertAsync(List<TEntity> RegistrosAInsertar);
        TEntity Insert(TEntity Entidad);
        Task UpdateAsync(TEntity Entidad);
        void Update(TEntity Entidad);
        Task DeleteAsync(TEntity Entidad);
        Task<TEntity> GetOneByIdAsync(Int32 ID, params Expression<Func<TEntity, Object>>[] Includes);
        Task<TEntity> GetOneAsync(Expression<Func<TEntity, Boolean>> Filtro, params Expression<Func<TEntity, Object>>[] Includes);
        Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, Object>>[] Includes);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> Filtro, params Expression<Func<TEntity, Object>>[] Includes);
    }
}