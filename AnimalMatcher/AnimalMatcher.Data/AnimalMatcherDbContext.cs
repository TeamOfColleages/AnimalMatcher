namespace AnimalMatcher.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AnimalMatcherDbContext : IdentityDbContext
    {
        public AnimalMatcherDbContext(DbContextOptions<AnimalMatcherDbContext> options)
            : base(options)
        {
        }
    }
}
