using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDemoWebAPI.Model;
using MovieDemoWebAPI.Service;

namespace MovieDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public readonly IMovieDemoWebAPI _movieDemoWebAPI;

        public MovieController(IMovieDemoWebAPI movieDemoWebAPI)
        {
            _movieDemoWebAPI= movieDemoWebAPI;
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
           var response= _movieDemoWebAPI.GetMoviesList();
            return Ok(response);
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMovieById(int movieId)
        {
            var response=_movieDemoWebAPI.GetMovieById(movieId);
            return Ok(response);

        }

        [HttpPost]
        public  IActionResult CreateMovie([FromBody] Movie movie)
        {
            if(movie == null)
            {
                return BadRequest("Entered movie details are incorrect");
            }
            _movieDemoWebAPI.CreateMovie(movie);
            return StatusCode(StatusCodes.Status201Created,new {message= "Movie Created"});

        }

        [HttpPut]
        public IActionResult EditMovie([FromBody] Movie movie)
        {
            if(movie==null)
            {
                return BadRequest("Entered movie details are incorrect");
            }
            _movieDemoWebAPI.EditMovie(movie);
            return Accepted("Movie Edited");
        }

    }
}
