using Microsoft.EntityFrameworkCore;
using Qs.Domain.Abstractions;

namespace Qs.Presentation.WebApi.Data;

public class DataContext : DbContext, IDataContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
}