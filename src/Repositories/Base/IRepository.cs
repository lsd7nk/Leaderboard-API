using Leaderboard.Models;

namespace Leaderboard.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetAsync(Guid id);
        public Task DeleteAsync(Guid id);
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
    }
}
