using System.Collections.Generic;
using System.Linq;
using TodoCommonLogic.Repository.Interfaces;
using TodoCommonLogic.Services.Interfaces;
using TodoDataAccess.Models;

namespace TodoCommonLogic.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IGenericRepository<Activity> ActivityRepository => _unitOfWork.ActivityRepository;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Activity> GetAllActivieties()
        {
            IEnumerable<Activity> listOfActivieties = ActivityRepository.GetAll();
            return listOfActivieties;
        }

        public Activity GetActivieties(int id)
        {
            Activity activieties = ActivityRepository.GetBy(value => value.Id.Equals(id)).FirstOrDefault();
            return activieties;
        }

        public IEnumerable<Activity> GetActivieties(int[] id)
        {
            IEnumerable<Activity> activieties = ActivityRepository.GetBy(value => id.Contains(value.Id));
            return activieties;
        }

        public IEnumerable<Activity> GetActivietiesByStatus(bool status)
        {
            IEnumerable<Activity> activieties = ActivityRepository.GetBy(value => value.IsCompleted.Equals(status));
            return activieties;
        }

        public Activity CreateActivity(Activity activity)
        {
            Activity newActivity = ActivityRepository.Add(activity);
            _unitOfWork.SaveChanges();

            return newActivity;
        }

        public Activity UpdateActivities(int id, Activity activity)
        {
            ActivityRepository.Edit(activity);
            _unitOfWork.SaveChanges();

            return activity;
        }

        public IEnumerable<Activity> UpdateActivities(List<Activity> activities)
        {
            foreach (Activity activity in activities.ToList())
            {
                ActivityRepository.Edit(activity);
            }
            _unitOfWork.SaveChanges();

            return activities;
        }

        public bool DeleteActivities(Activity activity)
        {
            ActivityRepository.Delete(activity);
            bool removed = _unitOfWork.SaveChanges() > 0; 

            return removed;
        }

        public bool DeleteActivities(List<Activity> activities)
        {
            foreach (Activity activity in activities.ToList())
            {
                ActivityRepository.Delete(activity);
            }
            bool removed = _unitOfWork.SaveChanges() > 0;

            return removed;
        }
    }
}
