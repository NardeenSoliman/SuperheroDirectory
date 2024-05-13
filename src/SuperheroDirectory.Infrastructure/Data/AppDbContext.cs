using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperheroDirectory.Application;
using SuperheroDirectory.Domain.Models;


namespace SuperheroDirectory.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>, IUnitOfWork
    {
        public DbSet<FavouriteSuperhero> FavouriteSuperheroes { set; get; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
