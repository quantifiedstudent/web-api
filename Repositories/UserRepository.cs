using QSWebAPI.Models;
using QSWebAPI.Repositories.Base;

namespace QSWebAPI.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly DataContext _dataContext;
    
    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    ///     Get all users async
    /// </summary>
    public async Task<List<User>> GetAllAsync()
    {
        return await _dataContext.Users.ToListAsync();
    }

    /// <summary>
    ///     Find user by their userId async
    /// </summary>
    public async Task<User> FindAsync(int id)
    {
        return await _dataContext.Users.FindAsync(id);
    }

    /// <summary>
    ///     Update the provided user
    /// </summary>
    public async Task<User> Update(User entity)
    {
        var dbUser = await _dataContext.Users.FindAsync(entity.Id);
        
        if(dbUser != null)
            dbUser.FirstName = entity.FirstName; 
            dbUser.LastName = entity.LastName;
            dbUser.UserName = entity.UserName;
            dbUser.Email = entity.Email;

        await _dataContext.SaveChangesAsync();
        return dbUser;
    }

    /// <summary>
    ///     Delete the provided user
    /// </summary>
    public async Task<User> Add(User entity)
    {
        _dataContext.Users.Add(entity);
        await _dataContext.SaveChangesAsync();
        return entity;
    }
    
    /// <summary>
    ///     Delete the user with the specified UserId async
    /// </summary>
    public async Task<User> DeleteAsync(int id)
    {
        var dbUser = await _dataContext.Users.FindAsync(id);

        if (dbUser == null)
            return dbUser;

        _dataContext.Users.Remove(dbUser);
        await _dataContext.SaveChangesAsync();
        return dbUser;
    }
}