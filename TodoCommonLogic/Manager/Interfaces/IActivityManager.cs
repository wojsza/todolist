using System.Collections.Generic;
using TodoCommonLogic.Models;
using TodoDataAccess.Models;

namespace TodoCommonLogic.Manager.Interfaces
{
    public interface IActivityManager
    {
        #region get elements
        IEnumerable<Activity> GetAllActivities();
        ActivitiesList GetAllActivitiesViewModel();

        Activity GetActivitiesById(int id);

        IEnumerable<Activity> GetActivitiesById(int[] id);
        ActivitiesList GetGetActivitiesByIdViewModel(int[] id);

        IEnumerable<Activity> GetActivitiesByStatus(bool isCompleted);
        ActivitiesList GetGetActivitiesByStatusViewModel(bool isCompleted);
        #endregion

        Activity CreateActivity(Activity activity);
        
        Activity UpdateActivities(int id, Activity activity);
        IEnumerable<Activity> UpdateActivities(List<Activity> activities);

        bool DeleteActivities(Activity activity);
        bool DeleteActivities(List<Activity> activities);
    }
}
