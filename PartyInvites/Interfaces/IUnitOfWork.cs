using PartyInvites.Models;

namespace PartyInvites.Interfaces
{
    public interface IUnitOfWork
    {
        //Data Accessors
        public IRepository<GuestResponse> GuestResponse { get; }
        //save changes to data source
        void Commit();
        //same but an Asynchronous Commit
        Task<int> CommitAsync();

    }
}
