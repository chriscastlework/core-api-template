namespace core_api_template.Models;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Authentication request object
/// </summary>
public class AuthenticateRequest
{
    /// <summary>
    /// User name
    /// </summary>
    /// <example>test</example>
    [Required]
    public string Username { get; set; } = "test";


    /// <summary>
    /// User password
    /// </summary>
    /// <example>Test</example>
    [Required]
    public string Password { get; set; } = "test";
}