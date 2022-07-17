namespace core_api_template.Entities;

using System.Text.Json.Serialization;

/// <summary>
/// User model
/// </summary>
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Username { get; set; } = "";

    [JsonIgnore]
    public string Password { get; set; } = "";
}