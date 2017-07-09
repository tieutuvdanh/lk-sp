using LikeSport.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeSport.Model;

namespace LikeSport.Data.Respositories
{
    public interface IActivityRepository : IRepository<Activity>
    {
        Activity GetActivityByName(string activityName);
        IEnumerable<Activity> GetAllActivities();
    }
    public class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
    {
        public ActivityRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Activity GetActivityByName(string activityName)
        {
            return this.DbContext.Activities.FirstOrDefault(act => act.ActivityName == activityName);
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return this.DbContext.Activities.OrderByDescending(m=>m.CreatedDate);
        }

        public Activity Add(Activity entity)
        {
            throw new NotImplementedException();
        }

        public Activity Delete(Activity entity)
        {
            throw new NotImplementedException();
        }

        public Activity Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

  
}
