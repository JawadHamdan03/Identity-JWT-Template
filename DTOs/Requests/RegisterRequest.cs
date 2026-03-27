

using System.ComponentModel.DataAnnotations;

namespace SecAndIdentity.DTOs.Requests;


public class RegisterRequest 
{
    [Required]
    public string? UserName { get; set; }
    
    [Required] 
    [EmailAddress]   
    public string Email { get; set; }

    [Required]
    public string? Password { get; set; }
}