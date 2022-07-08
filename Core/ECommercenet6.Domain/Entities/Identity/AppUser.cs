using Microsoft.AspNetCore.Identity;

namespace ECommercenet6.Domain.Entities.Identity;

public class AppUser:IdentityUser<string>
{
    public string NameSurName { get; set; }
}