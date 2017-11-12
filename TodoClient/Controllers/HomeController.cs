using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoCommonLogic.Manager.Interfaces;
using TodoCommonLogic.Models;
using TodoDataAccess.Models;

namespace TodoClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActivityManager _activityManager;

        public HomeController(IActivityManager activityManager)
        {
            _activityManager = activityManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public ActivitiesList GetAllForecasts()
        {
            ActivitiesList activieties = _activityManager.GetAllActivitiesViewModel();
            return activieties;
        }

        [HttpPost("[action]")]
        public Activity PostActivity([FromBody] Activity activity)
        {
            Activity createdActivity = _activityManager.CreateActivity(activity);
            return createdActivity;
        }

        [HttpDelete("[action]")]
        public bool ClearActivity([FromQuery]int[] id)
        {
            List<Activity> mockActivieties = new List<Activity>();
            foreach(int value in id)
            {
                mockActivieties.Add(new Activity { Id = value });
            }

            bool createdActivity = _activityManager.DeleteActivities(mockActivieties);
            return createdActivity;
        }

        [HttpPut("[action]")]
        public Activity UpdateActivity([FromBody]Activity activity)
        {
            Activity updateActivity = _activityManager.UpdateActivities(activity.Id, activity);
            return updateActivity;
        }
    }
}
