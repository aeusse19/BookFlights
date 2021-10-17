using BookFlights.Business.Data;
using BookFlights.Business.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFlights.Business.Repositories.Implementation
{
    public class BusinessRepository<TEntity> : IBusinessRepository<TEntity> where TEntity : class
    {
        private readonly BookFlightsContext bookFlightsContext;

        public BusinessRepository(BookFlightsContext bookFlightsContext)
        {
            this.bookFlightsContext = bookFlightsContext;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            bookFlightsContext.Set<TEntity>().Remove(entity);
            await bookFlightsContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await bookFlightsContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await bookFlightsContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            bookFlightsContext.Set<TEntity>().Add(entity);
            await bookFlightsContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            //bookFlightsContext.Entry(entity).State = EntityState.Modified;
            bookFlightsContext.Set<TEntity>().AddOrUpdate(entity);
            await bookFlightsContext.SaveChangesAsync();
            return entity;
        }
    }

}
