using Microsoft.EntityFrameworkCore;
using Qs.Persistence.Abstractions;

namespace Qs.Persistence;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
}