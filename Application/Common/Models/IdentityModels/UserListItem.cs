namespace ETAPP.Application.Common.Models.IdentityModels;

public class UserListItem
{
    public int Id { set; get; }

    public string? Username { set; get; } = null!;

    public string? Role { set; get; } = null!;

    public string? FirstName { set; get; }

    public string? LastName { set; get; }

    public string? FullName => $"{FirstName} {LastName}";
}

public class UserModel
{
    public int Id { set; get; }

    public string? Username { set; get; } = null!;

    public string? Role { set; get; } = null!;

    public string? FirstName { set; get; }

    public string? LastName { set; get; }
}