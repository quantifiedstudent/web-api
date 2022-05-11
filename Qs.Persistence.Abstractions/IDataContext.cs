using Microsoft.EntityFrameworkCore;

namespace Qs.Domain.Abstractions;

public interface IDataContext
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}