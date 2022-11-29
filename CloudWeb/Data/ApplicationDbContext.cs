using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            if (Roles.Where(p => p.Name == "User").FirstOrDefault() == null)
            {
                var Role = new IdentityRole("User");
                this.Roles.Add(Role);
                this.SaveChanges();
                string email = "strizakov00@gmail.com", CapsEmail = "STRIZAKOV00@GMAIL.COM";
                
                var User = new IdentityUser
                {
                    UserName = email,
                    NormalizedUserName = CapsEmail,
                    Email = email,
                    NormalizedEmail = CapsEmail,
                    EmailConfirmed = true,
                };
                User.PasswordHash = (new PasswordHasher<IdentityUser>()).HashPassword(User, "User");
                this.Users.Add(User);
                this.SaveChanges();

                var Claim = new IdentityUserRole<string> { RoleId = Roles.Where(r => r.Name == "User").First().Id, UserId = Users.Where(r => r.Email == email).First().Id };
                UserRoles.Add(Claim);
                SaveChanges();
            }
            
            if (Roles.Where(p => p.Name == "Admin").FirstOrDefault() == null)
            {
                var Role = new IdentityRole("Admin");
                this.Roles.Add(Role);
                this.SaveChanges();
                string email = "Admin@gmail.com", CapsEmail = "ADMIN@GMAIL.COM";

                var User = new IdentityUser
                {
                    UserName = email,
                    NormalizedUserName = CapsEmail,
                    Email = email,
                    NormalizedEmail = CapsEmail,
                    EmailConfirmed = true,
                };
                User.PasswordHash = (new PasswordHasher<IdentityUser>()).HashPassword(User, "Admin");
                this.Users.Add(User);
                this.SaveChanges();

                var Claim = new IdentityUserRole<string> { RoleId = Roles.Where(r => r.Name == "Admin").First().Id, UserId = Users.Where(r => r.Email == email).First().Id };
                UserRoles.Add(Claim);
                SaveChanges();
            }
        }
    }
}