using BookFlights.Business.Repositories.Contracts;
using BookFlights.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFlights.Business.Services.Implementation
{
    public class BusinessService<TEntity> : IBusinessService<TEntity> where TEntity : class
    {
        private IBusinessRepository<TEntity> businessRepository;

        public BusinessService(IBusinessRepository<TEntity> businessRepository)
        {
            this.businessRepository = businessRepository;
        }

        public async Task Delete(int id)
        {
            await businessRepository.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await businessRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await businessRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await businessRepository.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await businessRepository.Update(entity);
        }
    }
}
