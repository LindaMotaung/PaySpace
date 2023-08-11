using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using PaySpace.DataLayer.Data;
using PaySpace.DataLayer.Interfaces.Core;

namespace PaySpace.DataLayer.Core
{
    public class Repository<TEntity, TInterface> : IRepositoryWithCreate<TInterface>
        where TEntity : class, TInterface, new()
        where TInterface : class
    {
        protected readonly PaySpaceContext context;

        public Repository(PaySpaceContext paySpaceContext)
        {
            context = paySpaceContext;
        }

        protected DbSet<TEntity> DbSet => context.Set<TEntity>();

        public IQueryable<TInterface> GetAll()
        {
            try
            {
                return DbSet;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public TInterface Add(TInterface entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Add((TEntity)entity);

            return entity;
        }

        public void Remove(TInterface entity)
        {
            DbSet.Remove((TEntity)entity);
        }

        public TInterface Update(TInterface entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DbSet.Update((TEntity)entity);

            return entity;
        }

        TInterface ICreate<TInterface>.Create()
        {
            return new TEntity();
        }
    }
}
