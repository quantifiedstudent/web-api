using System.ComponentModel.DataAnnotations;
using qs_web_api.Models.Enums;

namespace qs_web_api.Models;

// <summary>
//     The User Model
//  </summary>
public class User
{
    
    // <summary>
    //     Unique identifier of the User.
    //  </summary>
    [Required]
    public int Id;
    
    // <summary>
    //     First name of the User.
    //  </summary>
    [Required]
    public string FirstName { get; set; }

    // <summary>
    //     Last name of the User.
    //  </summary>
    [Required]
    public string LastName { get; set; }
    
    // <summary>
    //     Username of the User.
    //  </summary>
    [Required]
    public string UserName { get; set; }
    
    // <summary>
    //     Email of the User.
    //  </summary>
    [Required]
    public string Email { get; set; }
    
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
    public string ExternalIdentityId { get; set; }
    
}