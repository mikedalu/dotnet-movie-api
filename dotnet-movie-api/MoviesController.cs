using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_movie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly OmdbApiClient _omdbApiClient;

        public MoviesController(OmdbApiClient omdbApiClient)
        {
            _omdbApiClient = omdbApiClient;
        }

        // GET api/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var movie = await _omdbApiClient.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // GET api/search/{title}
        [HttpGet("search/{title}")]
        public async Task<IActionResult> Search(string title)
        {
            var searchResult = await _omdbApiClient.GetMovieByTitle(title);
            Console.WriteLine(searchResult);
            Console.WriteLine("Hellow world");

            if (searchResult == null || searchResult == null )
            {
                return NotFound();
            }
            return Ok(searchResult);
        }

       

    }
}
