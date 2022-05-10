using System.ComponentModel.DataAnnotations;
using QSWebAPI.Models.Enums;

namespace QSWebAPI.Models;

// <summary>
//     The User Model
//  </summary>
public class User
{
    
    // <summary>
    //     Unique identifier of the User.
    //  </summary>
    [Required]
    public int Id { get; set; }
    
    // <summary>
    //     First name of the User.
    //  </summary>
    [Required] public string FirstName { get; set; } = string.Empty;

    // <summary>
    //     Last name of the User.
    //  </summary>
    [Required]
    public string LastName { get; set; } = string.Empty;
    
    // <summary>
    //     Username of the User.
    //  </summary>
    [Required]
    public string UserName { get; set; } = string.Empty;
    
    // <summary>
    //     Email of the User.
    //  </summary>
    [Required]
    public string Email { get; set; } = string.Empty;
    
    // <summary>
    //     Role of the User.
    //  </summary>
    [Required]
    public UserRole Role { get; set; }
    
    // <summary>
    //     Account login type of the User.
    //  </summary>
    [Required]
    public AccountLoginType AccountLoginType { get; set; }
    
    // <summary>
    //     External Identity Id of the User.
    //  </summary>
    public string ExternalIdentityId { get; set; } = string.Empty;
    
}