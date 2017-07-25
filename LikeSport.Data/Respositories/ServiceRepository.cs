using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeSport.Data.Infrastructure;
using LikeSport.Model;

namespace LikeSport.Data.Respositories
{
    public interface IServiceRepository : IRepository<Service>
    {
        IEnumerable<Service> GetAllServices();
    }
    public  class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Service Add(Service entity)
        {
            throw new NotImplementedException();
        }

        public Service Delete(Service entity)
        {
            throw new NotImplementedException();
        }

        public Service Delete(int id)
        {
            throw new NotImplementedException();
        }

     

        public IEnumerable<Service> GetAllServices()
        {
            return this.DbContext.Services.OrderByDescending(m => m.Id);
        }
    }
}
