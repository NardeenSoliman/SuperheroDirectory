using Microsoft.AspNetCore.Mvc;
using SuperheroDirectory.Application.Dtos.Base;
using SuperheroDirectory.Application.Services.Abstractions;

namespace SuperheroDirectory.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class SuperheroController : ControllerBase
    {
        public ISuperheroService _superheroService;

        public SuperheroController(ISuperheroService superheroService)
        {
            _superheroService = superheroService;
        }

        [HttpGet("search/{superheroName}")]
        public async Task<BaseResponse> Search(string superheroName)
        {
            return await _superheroService.SearchSuperhero(superheroName);
        }
    }
}
