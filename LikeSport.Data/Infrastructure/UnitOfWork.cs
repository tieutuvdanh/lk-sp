using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeSport.Data.Infrastructure
{
    // class not inherited.
    /// <summary>
    /// UnitOfWork use for call Initial object DbContext. only use one dbcontext for all depository.
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        // Inteface Refer to Factory.
        private readonly IDbFactory dbFactory;

        // property refer DBContext ActivirySport
        private ActivitySportDbContext dbContext;

        // refer use contructor:
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        // return dbContext object.
        public ActivitySportDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        void IUnitOfWork.Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
