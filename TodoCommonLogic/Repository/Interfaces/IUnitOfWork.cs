using TodoDataAccess.Models;

namespace TodoCommonLogic.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Activity> ActivityRepository { get; }

        int SaveChanges();
    }
}
