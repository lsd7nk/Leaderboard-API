using Microsoft.EntityFrameworkCore;
using Leaderboard.Models;

namespace Leaderboard.Repositories
{
    public sealed class EntityRepository<T> : IRepository<T> where T : Entity
    {
        private readonly DbContext _context;

        public EntityRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _context.SaveChangesAsync();
        }
    }
}
