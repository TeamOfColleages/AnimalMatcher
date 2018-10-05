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

        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Owner>()
                .HasMany(owner => owner.Pets)
                .WithOne(pet => pet.Owner)
                .HasForeignKey(pet => pet.OwnerId);

            base.OnModelCreating(builder);
        }
    }
}
