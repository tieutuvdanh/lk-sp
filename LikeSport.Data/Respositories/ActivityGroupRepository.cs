using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeSport.Data.Infrastructure;
using LikeSport.Model;

namespace LikeSport.Data.Respositories
{
    public interface IActivityGroupRepository : IRepository<ActivityGroup>
    {
        ActivityGroup GetActivityGroupByName(string activityName);
        IEnumerable<ActivityGroup> GetAllActivityGroups();
        IEnumerable<ActivityGroup> GetAllByMulti(List<int> listId);
    }
   public  class ActivityGroupRepository : RepositoryBase<ActivityGroup>, IActivityGroupRepository
    {
        public ActivityGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public ActivityGroup GetActivityGroupByName(string activityName)
        {
            return this.DbContext.ActivityGroups.FirstOrDefault(act => act.ActivityGroupName == activityName);
        }

        public IEnumerable<ActivityGroup> GetAllActivityGroups()
        {
            return this.DbContext.ActivityGroups.OrderByDescending(m => m.CreatedDate);
        }
        public IEnumerable<ActivityGroup> GetAllByMulti(List<int> listId)
        {
            return this.DbContext.ActivityGroups.Where(m => listId.Contains(m.Id));
        }
    }
}
