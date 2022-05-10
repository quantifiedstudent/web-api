using Microsoft.AspNetCore.Mvc;
using QSWebAPI.Models;

namespace QSWebAPI.Services.Base;

public interface IService<TEntity> where TEntity : class
{
    /// <summary>
    ///     Get all entities
    /// </summary>
    Task<List<TEntity>> GetAllAsync();

    /// <summary>
    ///     Find an entity async
    /// </summary>
    Task<TEntity> FindAsync(int id);

    /// <summary>
    ///     Update an entity
    /// </summary>
    Task<TEntity> Update(TEntity entity);
    
    /// <summary>
    ///     Create an entity
    /// </summary>
    Task<TEntity> Add(TEntity entity);
    
    /// <summary>
    ///     Delete an entity
    /// </summary>
    Task<TEntity> DeleteAsync(int id);
}