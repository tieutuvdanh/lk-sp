using LikeSport.Data;
using LikeSport.Data.Infrastructure;
using LikeSport.Data.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeSport.Model;

namespace LikeSport.Service
{
    public interface IActivityService
    {
        IEnumerable<Activity> GetAllActivity();
        Activity Add(Activity activity);
        Activity GetById(int id);
        void Update(Activity activity);
        Activity Delete(int id);
        void SaveActivity();

    }

    public class ActivityService : IActivityService
    {
        // Property is readonly is meaning only set one time in contructor. after it will never change value refer.
        private readonly IActivityRepository _activityRepository;

        private readonly IUnitOfWork _unitOfWork;

        // technology: DI --> better code with :Dependency Container. with Autofactory framework.
        public ActivityService(IActivityRepository activityRepository, IUnitOfWork unitOfWork)
        {
            this._activityRepository = activityRepository;
          
            this._unitOfWork = unitOfWork;
        }
        public Activity Add(Activity activity)
        {
           return _activityRepository.Add(activity);
        }

        public Activity GetById(int id)
        {
            return _activityRepository.GetSingleById(id);
        }

        public IEnumerable<Activity> GetAllActivity()
        {
            return _activityRepository.GetAll(new string[] { "ActivityGroup" });
        }
        public void SaveActivity()
        {
            _unitOfWork.Commit();
        }
        public void Update(Activity activity)
        {
            _activityRepository.Update(activity);
        }
        public Activity Delete(int id)
        {
          return  _activityRepository.Delete(id);
        }
    }

  
}
