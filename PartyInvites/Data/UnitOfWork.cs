using PartyInvites.Interfaces;
using PartyInvites.Models;

namespace PartyInvites.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        //Dependency Injection of the DB Service

        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private IRepository<GuestResponse> _GuestResponse;
        public IRepository<GuestResponse> GuestResponse
        {
            get
            {

                _GuestResponse ??= new Repository<GuestResponse>(_dbContext);
                return _GuestResponse;
            }
        }
        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }

}
