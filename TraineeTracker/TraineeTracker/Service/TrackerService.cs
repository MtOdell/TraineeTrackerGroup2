using TraineeTracker.Data;
using TraineeTracker.Models;

namespace TraineeTracker.Service
{
    public class TrackerService : IServiceLayer<Tracker>
    {
        private readonly TraineeTrackerContext _context;

        public TrackerService(TraineeTrackerContext context) => _context = context;

        public async Task AddAsync(Tracker entity)
        {
            _context.TrackerDB.Add(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return (_context.TrackerDB?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        public async Task<Tracker?> FindAsync(int id)
        {
            return await _context.TrackerDB.FindAsync(id);
        }

        //public async Task<string> GetAllAsync()
        //{
        //    return "Hello";
        //}

        public Task<Tracker?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Tracker entity)
        {
            _context.TrackerDB.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Tracker entity)
        {
            _context.TrackerDB.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
