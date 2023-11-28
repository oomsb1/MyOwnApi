using Microsoft.EntityFrameworkCore;

namespace MyOwnAPI.Domain.Interfaces
{
    public interface IReadDbContext: IDisposable
    {
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
