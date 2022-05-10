using Microsoft.EntityFrameworkCore;
using QSWebAPI.Models;

namespace QSWebAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    /// <summary>
    ///     DBSet containing User-entities.
    /// </summary>
    public DbSet<User> Users { get; set; }
}