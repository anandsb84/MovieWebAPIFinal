using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDemoWebAPI.Model;
using MovieDemoWebAPI.Service;

namespace MovieDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        public readonly IMovieDemoWebAPI _movieDemoWebAPI;

        public ProducerController(IMovieDemoWebAPI movieDemoWebAPI)
        {
            _movieDemoWebAPI = movieDemoWebAPI;
        }

        [HttpGet]
        public IActionResult GetProducer()
        {
           var response= _movieDemoWebAPI.GetProducerList();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateProducer([FromBody] Producer producer)
        {
            if(producer==null)
            {
                return BadRequest("Entered Details are incorrect");
            }
            _movieDemoWebAPI.CreateProducer(producer);
            return StatusCode(StatusCodes.Status201Created, new { message = "Producer Created" });
        }
    }
}
