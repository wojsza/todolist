using System.Collections.Generic;
using System.Linq;
using TodoDataAccess.Models;

namespace TodoCommonLogic.Models
{
    public class ActivitiesList
    {
        public IEnumerable<Activity> Activieties { get; set; }

        public int TotalActivieties => Activieties?.Count() ?? 0;

        public int CopmpletedActivieties => Activieties?.Count(activity => activity.IsCompleted) ?? 0;

        public int NotCompletedActivieties => Activieties?.Count(activity => !activity.IsCompleted) ?? 0;
    }
}
