namespace Qs.Persistence.Abstractions;


public interface IContext
{ 
    public int SaveChanges(); 
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}
