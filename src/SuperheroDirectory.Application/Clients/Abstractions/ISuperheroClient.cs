using SuperheroDirectory.Application.Clients.Dtos;

namespace SuperheroDirectory.Application.Clients.Abstractions
{
    public interface ISuperheroClient
    {
        Task<SearchSuperheroResult> SearchSuperhero(string superheroName);
    }
}
