using BookShop.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration;

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    // Fixed concurrency stamp for seeded users and roles.
    private static readonly Guid FixConcurrencyStamp = new("5610e8cb-6f66-4e89-ba44-3287259857a5");

    /// <summary>
    /// Fix hash for "Password123!". The initalization must be deterministic so we need to hardcode this value.
    /// <para>
    /// Generated with: PasswordHasher<ApplicationUser>.HashPassword(user, "Password123!")
    /// </para>
    /// </summary>
    private static readonly string FixPasswordHash = "AQAAAAIAAYagAAAAEN+jQMxxcf6j/Qh5W23vp91R/ehaCa1xXEEqJuyAyHJvnRxOpK1COKRG/Tb0CdQCxg==";

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(e => e.Id);
    }

    public static void SeedData(ModelBuilder builder)
    {
        FixPasswordHash.ToString();
        builder.Entity<ApplicationUser>().HasData(CreateUsers());
        builder.Entity<IdentityRole<int>>().HasData(CreateRoles());
        builder.Entity<IdentityUserRole<int>>().HasData(CreateUserInRoles());
    }

    public static List<ApplicationUser> CreateUsers()
    {
        List<ApplicationUser> users = [];
        users.Add(GenerateUser("admin@example.com", /*"Password123!",*/ 1, "Admin Aladár"));
        users.Add(GenerateUser("user@example.com", /*"Password123!",*/ 2, "Felhasználó Ferenc"));

        return users;
    }

    public static List<IdentityRole<int>> CreateRoles()
    {
        List<IdentityRole<int>> roles = [];
        roles.Add( GenerateRole("Admin", 1));

        return roles;
    }

    public static List<IdentityUserRole<int>> CreateUserInRoles()
    {
        List<IdentityUserRole<int>> userInRoles = [];
        userInRoles.Add(new IdentityUserRole<int>{ UserId = 1, RoleId = 1 });

        return userInRoles;
    }

    private static ApplicationUser GenerateUser(string email, /*string password,*/ int id, string displayName)
    {
        var user = new ApplicationUser
        {
            Id = id,
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            DisplayName = displayName,
            ConcurrencyStamp = FixConcurrencyStamp.ToString(),
            SecurityStamp = FixConcurrencyStamp.ToString(),
        };

        user.NormalizedUserName = user.UserName.ToUpperInvariant();
        user.NormalizedEmail = user.Email.ToUpperInvariant();

        // Cannot be used directly in the SeedData method because of the deterministic initialization requirement,
        // so we hash the password once with this code and then hardcode the value in FixPasswordHash.
        // PasswordHasher<ApplicationUser> hasher = new();
        // user.PasswordHash = hasher.HashPassword(user, password);

        // FixPasswordHash ??= hasher.HashPassword(user, password);
        user.PasswordHash = FixPasswordHash;

        return user;
    }

    private static IdentityRole<int> GenerateRole(string roleName, int id)
    {
        var role = new IdentityRole<int>(roleName) 
        {
            Id = id,
            ConcurrencyStamp = FixConcurrencyStamp.ToString()
        };

        role.NormalizedName = role.Name!.ToUpperInvariant();

        return role;
    }
}