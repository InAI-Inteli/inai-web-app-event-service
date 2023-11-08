using Microsoft.EntityFrameworkCore;
using WebAPIEventService.Domain.Entities;
using WebAPIEventService.Infra.Data.Context;
using WebAPIEventService.Infra.Data.Repository.Interfaces;

namespace WebAPIEventService.Infra.Data.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly EventContext _context;

        public BaseRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity
        {
            return await _context.Set<T>().ToListAsync();
        }
        public void Add<T>(T entity) where T : BaseEntity
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;
            entity.UpdatedAt = DateTime.Now;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _context.Remove(entity);
        }
    }
}
