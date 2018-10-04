namespace AnimalMatcher.Data
{
    using AnimalMatcher.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AnimalMatcherDbContext : IdentityDbContext
    {
        public AnimalMatcherDbContext(DbContextOptions<AnimalMatcherDbContext> options)
            : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Owner>()
                .HasMany(owner => owner.Pets)
                .WithOne(animal => animal.Owner)
                .HasForeignKey(animal => animal.OwnerId);

            base.OnModelCreating(builder);
        }
    }
}
