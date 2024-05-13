using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroDirectory.Domain.Models
{
    public class FavouriteSuperhero
    {
        [Key]
        public long Id { set; get; }

        public string UserId { set; get; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { set; get; }

        public string SuperheroId { set; get; }

        public string SuperheroName { set; get; }
    }
}