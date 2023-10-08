using System.Data.Entity;

namespace ReadingCorpBookApp.Repository.Infrastructure.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext dbContext { get; }

    }
}
