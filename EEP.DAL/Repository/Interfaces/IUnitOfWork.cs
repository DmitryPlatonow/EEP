namespace EEP.DAL.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
    }
}
