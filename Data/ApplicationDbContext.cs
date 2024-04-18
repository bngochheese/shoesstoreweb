using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoesStoreWebsite.Models;
using Microsoft.AspNetCore.Identity;


namespace ShoesStoreWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShoesStoreWebsite.Models.Shoes> Shoes { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; }

    }
}
