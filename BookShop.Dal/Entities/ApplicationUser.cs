using Microsoft.AspNetCore.Identity;

namespace BookShop.Dal.Entities;

public class ApplicationUser : IdentityUser<int>
{
    [PersonalData]
    public string DisplayName { get; set; } = string.Empty;

    public virtual ICollection<Comment> Comments { get; set; } = [];
    public virtual ICollection<Rating> Ratings { get; set; } = [];
    public virtual ICollection<UserAddress> UserAddresses { get; set; } = [];
    public virtual ICollection<Order> Orders { get; set; } = [];
}
