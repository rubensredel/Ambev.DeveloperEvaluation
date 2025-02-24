namespace Ambev.DeveloperEvaluation.Application.Users.DeleteUser;

/// <summary>
/// Response model for DeleteUser operation
/// </summary>
public record DeleteUserResponse()
{
    /// <summary>
    /// Indicates whether the deletion was successful
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Error message if the deletion failed
    /// </summary>
    public string? Error { get; set; }
}
