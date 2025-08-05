using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Id = "ef5c4a95-3623-4c8b-adec-287d4d46f6da",
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE"
                    },
                    new IdentityRole
                    {
                        Id = "e92925ca-0050-4b57-81f8-5641806da52b",
                        Name = "Supervisor",
                        NormalizedName = "SUPERVISOR"
                    },
                    new IdentityRole
                    {
                        Id = "eeddc9d1-ebb1-408a-9b0d-22be8152b110",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    }
                );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    Id = "32921979-a794-43bc-9b24-b1e81eb280e8",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1990, 1, 1)
                });

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = "eeddc9d1-ebb1-408a-9b0d-22be8152b110",
                    UserId = "32921979-a794-43bc-9b24-b1e81eb280e8"
                });
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Period> Periods { get; set; }

    }
}
