using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medicion.Datos.Repositorio.Core
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected MedicionDbContext Context;

        public Repositorio(MedicionDbContext _context)
        {
            Context = _context;
        }

        #region Insert
        public virtual async Task<TEntity> InsertAsync(TEntity Entidad)
        {
            Context.Set<TEntity>().Add(Entidad);
            await Context.SaveChangesAsync();

            return Entidad;
        }

        public virtual async Task<List<TEntity>> InsertAsync(List<TEntity> RegistrosAInsertar)
        {
            foreach (TEntity item in RegistrosAInsertar)
            {
                Context.Set<TEntity>().Add(item);
            }
            await Context.SaveChangesAsync();

            return RegistrosAInsertar;
        }

        public virtual TEntity Insert(TEntity Entidad)
        {
                Context.Set<TEntity>().Add(Entidad);
                Context.SaveChanges();

                return Entidad;
        }
        #endregion

        #region Update
        public virtual async Task UpdateAsync(TEntity Entidad)
        {
                Context.Entry<TEntity>(Entidad).State = EntityState.Modified;
                await Context.SaveChangesAsync();
        }

        public virtual void Update(TEntity Entidad)
        {
                Context.Entry<TEntity>(Entidad).State = EntityState.Modified;
                Context.SaveChanges();
        }
        #endregion

        #region Delete
        public virtual async Task DeleteAsync(TEntity Entidad)
        {
                Context.Entry<TEntity>(Entidad).State = EntityState.Deleted;
                await Context.SaveChangesAsync();
        }
        #endregion

        #region GetOneByID
        public virtual async Task<TEntity> GetOneByIdAsync(Int32 ID, params Expression<Func<TEntity, Object>>[] Includes)
        {
                DbSet<TEntity> _dbSet = Context.Set<TEntity>();

                if (Includes != null)
                {
                    foreach (Expression<Func<TEntity, Object>> include in Includes)
                    {
                        _dbSet = _dbSet.Include(include) as DbSet<TEntity>;
                    }
                }

                return await _dbSet.FindAsync(ID);
        }
        #endregion

        #region GetOne
        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, Boolean>> Filtro, params Expression<Func<TEntity, Object>>[] Includes)
        {
                IQueryable<TEntity> query = Context.Set<TEntity>();

                if (Includes != null)
                {
                    foreach (Expression<Func<TEntity, Object>> include in Includes)
                    {
                        query = query.Include(include) as IQueryable<TEntity>;
                    }
                }

                return await query.Where(Filtro).FirstOrDefaultAsync();
        }
        #endregion

        #region GetList
        public virtual async Task<List<TEntity>> GetListAsync(params Expression<Func<TEntity, Object>>[] Includes)
        {
            return await GetListAsync(null, Includes);
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> Filtro, params Expression<Func<TEntity, Object>>[] Includes)
        {
                IQueryable<TEntity> query = Context.Set<TEntity>();

                if (Includes != null)
                {
                    foreach (Expression<Func<TEntity, Object>> include in Includes)
                    {
                        query = query.Include(include) as IQueryable<TEntity>;
                    }
                }

                if (Filtro != null)
                {
                    return query.Where(Filtro).ToList();
                }
                else
                {
                    return await query.ToListAsync();
                }
        }
        #endregion
    }
}