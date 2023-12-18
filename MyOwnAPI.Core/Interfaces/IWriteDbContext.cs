using Microsoft.EntityFrameworkCore;

namespace MyOwnAPI.Domain.Interfaces
{
    public interface IWriteDbContext : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Dispose();
    }
}
