using System.ComponentModel.DataAnnotations;

namespace SecAndIdentity.DTOs.Requests;


public class LoginRequest
{
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}