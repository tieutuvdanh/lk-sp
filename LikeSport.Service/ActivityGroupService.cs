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
    public interface IActivityGroupService
    {
        IEnumerable<ActivityGroup> GetAllActivityGroups();

        IEnumerable<ActivityGroup> GetNameAll();
        IEnumerable<ActivityGroup> GetAllByMulti(List<int> listId);
        ActivityGroup Add(ActivityGroup activityGroup);
        ActivityGroup GetById(int id);
        void Update(ActivityGroup activityGroup);
        ActivityGroup Delete(int id);
        void SaveChange();

    }
    public class ActivityGroupService: IActivityGroupService
    {
        // Property is readonly is meaning only set one time in contructor. after it will never change value refer.
        private readonly IActivityGroupRepository _activityGroupRepository;
        private readonly IActivityInformationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        // technology: DI --> better code with :Dependency Container. with Autofactory framework.
        public ActivityGroupService(IActivityGroupRepository activityGroupRepository, IUnitOfWork unitOfWork, IActivityInformationRepository repository)
        {
            this._activityGroupRepository = activityGroupRepository;

            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }
        public ActivityGroup Add(ActivityGroup activityGroup)
        {
            return _activityGroupRepository.Add(activityGroup);
        }

        public ActivityGroup GetById(int id)
        {
            return _activityGroupRepository.GetSingleById(id);
        }
        public IEnumerable<ActivityGroup> GetNameAll()
        {
            return _activityGroupRepository.GetAll();
        }
        public IEnumerable<ActivityGroup> GetAllActivityGroups()
        {
            //var list= _repository.GetMulti(x => x.Activity.ActivityGroup_Id == id, new string[] { "Promotions" });
       

            return _activityGroupRepository.GetAll(new string[] { "Activities" }).ToList().Where(item => _repository.GetMulti(x => x.Activity.ActivityGroup_Id == item.Id).Any()).ToList(); 

            //return _activityGroupRepository.GetAll();
        }
        public IEnumerable<ActivityGroup> GetAllByMulti(List<int> listId)
        {
            return _activityGroupRepository.GetAllByMulti(listId);
        }
        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
        public void Update(ActivityGroup activityGroup)
        {
            _activityGroupRepository.Update(activityGroup);
        }
        public ActivityGroup Delete(int id)
        {
            return _activityGroupRepository.Delete(id);
        }
    }
}
