using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDemoWebAPI.Model;
using MovieDemoWebAPI.Service;

namespace MovieDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        public readonly IMovieDemoWebAPI _movieDemoWebAPI;

        public ActorController(IMovieDemoWebAPI movieDemoWebAPI)
        {
            _movieDemoWebAPI = movieDemoWebAPI;
        }
        [HttpGet]
        public IActionResult GetActors()
        {
           var response= _movieDemoWebAPI.GetActors();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateActor([FromBody] Actor actor)
        {
            if(actor==null)
            {
                return BadRequest("Entered Details are incorrect");
            }
            _movieDemoWebAPI.CreateActor(actor);
            return StatusCode(StatusCodes.Status201Created, new { message = "Actor Created" });
        }

    }
}
