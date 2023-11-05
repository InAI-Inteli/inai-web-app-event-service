using WebAPIEventService.Infra.Data.Context;

namespace WebAPIEventService.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventContext _context;

        public UnitOfWork(EventContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {

        }
    }
}
