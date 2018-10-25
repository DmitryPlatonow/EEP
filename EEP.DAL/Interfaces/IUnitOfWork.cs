using System;
using System.Threading.Tasks;

namespace EEP.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
