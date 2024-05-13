using SuperheroDirectory.Domain.Models;
using SuperheroDirectory.Domain.Repositories;
using SuperheroDirectory.Infrastructure.Data;

namespace SuperheroDirectory.Infrastructure.Repositories
{
    public class SuperheroRepository : ISuperheroRepository
    {
        private readonly AppDbContext _context;
        public SuperheroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddFavourites(List<FavouriteSuperhero> superheros)
        {
            await _context.FavouriteSuperheroes.AddRangeAsync(superheros);
            await _context.SaveChangesAsync();
        }
    }
}
