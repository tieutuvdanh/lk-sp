using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeSport.Data.Infrastructure;
using LikeSport.Data.Respositories;
using LikeSport.Model;

namespace LikeSport.Service
{
    public interface IActivityInfomationService
    {
        IEnumerable<ActivityInformation> GetAll();
        IEnumerable<ActivityInformation> GetAllByActivityId(int id);
        IEnumerable<ActivityInformation> GetAllByMultiActivityId(List<int> listId );
        IEnumerable<ActivityInformation> GetAllByActivityGroupId(int id);
        ActivityInformation Add(ActivityInformation model);
        ActivityInformation GetById(int id);
        void Update(ActivityInformation model);
        ActivityInformation Delete(int id);
        void SaveChange();

    }
    public class ActivityInfomationService:IActivityInfomationService
    {
        private readonly IActivityInformationRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public ActivityInfomationService(IActivityInformationRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;

            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<ActivityInformation> GetAll()
        {
            return _repository.GetAll(new string[] { "Promotions" });
        }

        public IEnumerable<ActivityInformation> GetAllByActivityId(int id)
        {
            //return _repository.GetMulti(x => x.Activity_Id == id, new string[] { "Promotions" });
            return _repository.GetAllByActivityId(id);
        }

        public IEnumerable<ActivityInformation> GetAllByMultiActivityId(List<int> listId)
        {
            return _repository.GetAllByMultiActivityId(listId);
        }

        public IEnumerable<ActivityInformation> GetAllByActivityGroupId(int id)
        {
            return _repository.GetMulti(x => x.Activity.ActivityGroup_Id == id, new string[] { "Promotions" });
        }

        public ActivityInformation Add(ActivityInformation model)
        {
            return _repository.Add(model);
        }

        public ActivityInformation GetById(int id)
        {
            return _repository.GetSingleById(id);
        }

        public void Update(ActivityInformation model)
        {
            _repository.Update(model);
        }

        public ActivityInformation Delete(int id)
        {
            return _repository.Delete(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}
