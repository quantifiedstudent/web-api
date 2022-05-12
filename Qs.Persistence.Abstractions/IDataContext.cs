using Microsoft.EntityFrameworkCore;

namespace Qs.Persistence.Abstractions;

public interface IDataContext : IContext
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}