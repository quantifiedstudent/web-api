using Microsoft.AspNetCore.Mvc;
using QSWebAPI.Models;
using QSWebAPI.Repositories.Base;
using QSWebAPI.Services.Base;

namespace QSWebAPI.Services;

public class UserService : IService<User> 
{
    private readonly IRepository<User> _repository;
    
    public UserService(IRepository<User> repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    ///     Get all users async
    /// </summary>
    public Task<List<User>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    /// <summary>
    ///     Find user by their userId async
    /// </summary>
    public async Task<User> FindAsync(int id)
    {
        return await _repository.FindAsync(id);
    }

    /// <summary>
    ///     Update the provided user
    /// </summary>
    public Task<User> Update(User entity)
    {
        return _repository.Update(entity);
    }

    /// <summary>
    ///     Delete the provided user
    /// </summary>
    public Task<User> Add(User entity)
    {
        return _repository.Add(entity);
    }

    /// <summary>
    ///     Delete the user with the specified UserId async
    /// </summary>
    public async Task<User> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
    
}