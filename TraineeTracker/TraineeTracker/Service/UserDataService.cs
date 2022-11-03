using Microsoft.EntityFrameworkCore;
using TraineeTracker.Data;
using TraineeTracker.Models;

namespace TraineeTracker.Service
{
    public class UserDataService : IServiceLayer<UserData>
    {
        private readonly TraineeTrackerContext _context;

        public UserDataService(TraineeTrackerContext context) => _context = context;

        public async Task AddAsync(UserData entity)
        {
            _context.UserDataDB.Add(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return (_context.UserDataDB?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        public async Task<UserData?> FindAsync(int id)
        {
            return await _context.UserDataDB.FindAsync(id);
        }

        public async Task<IEnumerable<UserData>> GetAllAsync()
        {
            return await _context.UserDataDB.ToListAsync();
        }

        public bool IsNull()
        {
            return _context.UserDataDB == null;
        }

        public async Task RemoveAsync(UserData entity)
        {
            _context.UserDataDB.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(UserData entity)
        {
            _context.UserDataDB.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
