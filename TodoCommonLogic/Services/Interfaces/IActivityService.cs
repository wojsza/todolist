using System.Collections.Generic;
using TodoDataAccess.Models;

namespace TodoCommonLogic.Services.Interfaces
{
    public interface IActivityService
    {
        IEnumerable<Activity> GetAllActivieties();
        Activity GetActivieties(int id);
        IEnumerable<Activity> GetActivieties(int[] id);
        IEnumerable<Activity> GetActivietiesByStatus(bool status);


        Activity CreateActivity(Activity activity);


        Activity UpdateActivities(int id, Activity activity);
        IEnumerable<Activity> UpdateActivities(List<Activity> activities);

        bool DeleteActivities(Activity activity);
        bool DeleteActivities(List<Activity> activities);
    }
}
