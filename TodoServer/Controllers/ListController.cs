using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoCommonLogic.Manager.Interfaces;
using TodoDataAccess.Models;

namespace TodoServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ListController : Controller
    {
        private readonly IActivityManager _activityManager;

        public ListController(IActivityManager activityManager)
        {
            _activityManager = activityManager;
        }

        [HttpGet, ActionName("GetActivieties")]
        public IActionResult GetActivieties()
        {
            IEnumerable<Activity> activieties = _activityManager.GetAllActivities();
            if (activieties == null)
            {
                return NotFound();
            }

            return new ObjectResult(activieties);
        }
        
        [HttpGet("{id}"), ActionName("GetActivity")]
        public IActionResult GetActivity(int id)
        {
            Activity activity = _activityManager.GetActivitiesById(id);
            if (activity == null)
            {
                return NotFound();
            }

            return new ObjectResult(activity);
        }

        [HttpGet("{completed}"), ActionName("GetCompleted")]
        public IActionResult GetCompleted(bool completed)
        {
            IEnumerable<Activity> activieties = _activityManager.GetActivitiesByStatus(completed);
            if (activieties == null)
            {
                return NotFound();
            }

            return new ObjectResult(activieties);
        }
        
        [HttpGet, ActionName("GetActivietiesById")]
        public IActionResult GetActivietiesById([FromQuery]int[] id)
        {
            IEnumerable<Activity> activieties = _activityManager.GetActivitiesById(id);
            if (activieties == null)
            {
                return NotFound();
            }

            return new ObjectResult(activieties);
        }

        [HttpPost, ActionName("CreateActivity")]
        public IActionResult CreateActivity([FromBody]Activity activity)
        {
            if (activity == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _activityManager.CreateActivity(activity);

            return CreatedAtAction("CreateActivity", new {id = activity.Id, name = activity.Name, IsCompleted = activity.IsCompleted});
        }
        
        [HttpPut("{id}"), ActionName("UpdateActiviety")]
        public IActionResult UpdateActiviety(int id, [FromBody]Activity activity)
        {
            if (activity == null || activity.Id != id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _activityManager.UpdateActivities(id, activity);

            return CreatedAtAction("UpdateActiviety", new { name = activity.Name, isComplete = activity.IsCompleted });
        }

        [HttpPut, ActionName("UpdateActivieties")]
        public IActionResult UpdateActivieties([FromBody]List<Activity> activieties)
        {
            if (activieties == null) return BadRequest();
            if (activieties.Any(activitie => !TryValidateModel(activitie))) return BadRequest();

            _activityManager.UpdateActivities(activieties);

            return new ObjectResult(activieties);
        }

        [HttpDelete("{id}"), ActionName("DeleteActivity")]
        public IActionResult DeleteActivity(int id)
        {
            Activity activity = _activityManager.GetActivitiesById(id);
            if (activity == null) return NotFound();

            bool removed = _activityManager.DeleteActivities(activity);
            return new ObjectResult(removed);
        }

        [HttpDelete, ActionName("DeleteActivieties")]
        public IActionResult DeleteActivieties([FromQuery]int[] id)
        {
            IEnumerable<Activity> activieties = _activityManager.GetActivitiesById(id);
            if (activieties.Any()) return NotFound();
            if (!activieties.Count().Equals(id.Count())) return BadRequest();

            bool removed = _activityManager.DeleteActivities(activieties.ToList());
            return new ObjectResult(removed);
        }
    }
}
