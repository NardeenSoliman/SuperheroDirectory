using System.Text.RegularExpressions;

namespace SuperheroDirectory.Application.Dtos
{
    public class StoreFavoriteSuperhero
    {
        public string Id { set; get; }

        public bool IsValid()
        {
            Regex regex = new(@"[0-9]");
            return regex.IsMatch(Id);
        }
    }
}
