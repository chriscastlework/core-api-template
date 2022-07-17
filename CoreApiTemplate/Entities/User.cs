using System.Text.Json.Serialization;

namespace core_api_template.Entities;

/// <summary>
/// User model
/// </summary>
public class User
{
    public int Id { get; init; }
    public string? FirstName { get; init; } = "";
    public string? LastName { get; init; } = "";
    public string? Username { get; init; } = "";

    [JsonIgnore]
    public string Password { get; init; } = "";
}