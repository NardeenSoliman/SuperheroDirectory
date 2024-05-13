using Microsoft.AspNetCore.Identity;

namespace SuperheroDirectory.Domain.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            FavouriteSuperheroes = new();
        }

        public List<FavouriteSuperhero> FavouriteSuperheroes { set; get; }
    }
}
