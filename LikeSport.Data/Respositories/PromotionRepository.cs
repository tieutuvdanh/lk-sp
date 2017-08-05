using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeSport.Data.Infrastructure;
using LikeSport.Model;

namespace LikeSport.Data.Respositories
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        IEnumerable<Promotion> GetAll();

        
    }
    public class PromotionRepository : RepositoryBase<Promotion>, IPromotionRepository
    {
        public PromotionRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {
        }

        public IEnumerable<Promotion> GetAll()
        {
            return this.DbContext.Promotions.OrderByDescending(m => m.Id);
        }
       



    }
}
