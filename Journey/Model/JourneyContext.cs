
using Journy.Model.features;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Journy.Model
{
    public class JourneyContext : DbContext
    {
        public JourneyContext(DbContextOptions<JourneyContext> options) : base(options)
        { }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Pin> Pins { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserAccount>().HasIndex(r => r.Email).IsUnique();

        }
    }


}
