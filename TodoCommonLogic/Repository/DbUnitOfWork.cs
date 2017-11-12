using TodoCommonLogic.Repository.Interfaces;
using TodoDataAccess;
using TodoDataAccess.Models;

namespace TodoCommonLogic.Repository
{
    public class DbUnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Activity> _activityRepository;

        private readonly TodoDbContext _context;

        public IGenericRepository<Activity> ActivityRepository
            => _activityRepository ?? (_activityRepository = new DbGenericRepository<Activity>(_context));

        public DbUnitOfWork(TodoDbContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
