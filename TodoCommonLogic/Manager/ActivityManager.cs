using System.Collections.Generic;
using TodoCommonLogic.Manager.Interfaces;
using TodoCommonLogic.Models;
using TodoCommonLogic.Services.Interfaces;
using TodoDataAccess.Models;

namespace TodoCommonLogic.Manager
{
    public class ActivityManager : IActivityManager
    {
        private readonly IActivityService _activityService;

        public ActivityManager(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            IEnumerable<Activity> activitiesList = _activityService.GetAllActivieties();
            return activitiesList;
        }

        public Activity GetActivitiesById(int id)
        {
            Activity activity = _activityService.GetActivieties(id);
            return activity;
        }

        public IEnumerable<Activity> GetActivitiesById(int[] id)
        {
            IEnumerable <Activity> activitiesList = _activityService.GetActivieties(id);
            return activitiesList;
        }

        public IEnumerable<Activity> GetActivitiesByStatus(bool isCompleted)
        {
            IEnumerable<Activity> activities = _activityService.GetActivietiesByStatus(isCompleted);
            return activities;
        }

        public ActivitiesList GetAllActivitiesViewModel()
        {
            ActivitiesList activities = new ActivitiesList { Activieties = GetAllActivities() };
            return activities;
        }

        public ActivitiesList GetGetActivitiesByIdViewModel(int[] id)
        {
            throw new System.NotImplementedException();
        }

        public ActivitiesList GetGetActivitiesByStatusViewModel(bool isCompleted)
        {
            throw new System.NotImplementedException();
        }

        public Activity CreateActivity(Activity activity)
        {
            Activity newActivity = _activityService.CreateActivity(activity);
            return newActivity;
        }

        public Activity UpdateActivities(int id, Activity activity)
        {
            Activity updatedActivity = _activityService.UpdateActivities(id, activity);
            return updatedActivity;
        }

        public IEnumerable<Activity> UpdateActivities(List<Activity> activities)
        {
            IEnumerable<Activity> updatedActivities = _activityService.UpdateActivities(activities);
            return updatedActivities;
        }

        public bool DeleteActivities(Activity activity)
        {
            bool removed = _activityService.DeleteActivities(activity);
            return removed;
        }

        public bool DeleteActivities(List<Activity> activities)
        {
            bool removed = _activityService.DeleteActivities(activities);
            return removed;
        }
    }
}
