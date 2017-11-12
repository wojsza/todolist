using System;
using TodoCommonLogic.Models;
using TodoCommonLogic.Repository.Interfaces;
using TodoDataAccess;
using TodoDataAccess.Models;

namespace TodoCommonLogic.Repository
{
    public class ApiUnitOfWork : IUnitOfWork
    {
        private IGenericRepository<Activity> _activityRepository;

        private readonly TodoApiContext _context;

        public IGenericRepository<Activity> ActivityRepository
            => _activityRepository ?? (_activityRepository = new ApiGenericRepository<Activity>(_context));

        public ApiUnitOfWork(TodoApiContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            //todo check http status
            return 1;
        }
    }
}
