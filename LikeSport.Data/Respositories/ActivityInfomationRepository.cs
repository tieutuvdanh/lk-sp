using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeSport.Data.Infrastructure;
using LikeSport.Model;

namespace LikeSport.Data.Respositories
{
    public interface IActivityInformationRepository : IRepository<ActivityInformation>
    {
        IEnumerable<ActivityInformation> GetAll();

        IEnumerable<ActivityInformation> GetAllByActivityGroupId(int id);
        IEnumerable<ActivityInformation> GetAllByMultiActivityId(List<int> listId);
        IEnumerable<ActivityInformation> GetAllByActivityId(int id);
    }
    public class ActivityInfomationRepository : RepositoryBase<ActivityInformation>, IActivityInformationRepository
    {
        public ActivityInfomationRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<ActivityInformation> GetAll()
        {
            return this.DbContext.ActivityInformations.OrderByDescending(m => m.Id);
        }
        public IEnumerable<ActivityInformation> GetAllByActivityGroupId(int id)
        {
            return this.DbContext.ActivityInformations.Where(m=>m.Activity.ActivityGroup_Id==id);
        }

        public IEnumerable<ActivityInformation> GetAllByMultiActivityId(List<int> listId)
        {
            return this.DbContext.ActivityInformations.Where(m => listId.Contains(m.Activity_Id));
        }

        public IEnumerable<ActivityInformation> GetAllByActivityId(int id)
        {
            return this.DbContext.ActivityInformations.Where(m => m.Activity_Id == id);
        }
        public ActivityInformation Add(ActivityInformation entity)
        {
            throw new NotImplementedException();
        }

        public ActivityInformation Delete(ActivityInformation entity)
        {
            throw new NotImplementedException();
        }

        public ActivityInformation Delete(int id)
        {
            throw new NotImplementedException();
        }



       
    }
}
