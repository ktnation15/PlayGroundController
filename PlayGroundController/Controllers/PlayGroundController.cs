using Microsoft.AspNetCore.Mvc;
using PlayGroundLib;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlayGroundsController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayGroundsController : ControllerBase
    {
        private readonly PlayGroundsRepository _playGroundsRepository;

        public PlayGroundsController(PlayGroundsRepository playGroundsRepository)
        {
            _playGroundsRepository = playGroundsRepository;
        }
        // GET: api/<PlayGroundsRepository>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]// data found
        [ProducesResponseType(StatusCodes.Status204NoContent)]// data not found
        [ProducesResponseType(StatusCodes.Status404NotFound)]// data not found
        public ActionResult<IEnumerable<PlayGround>> Get([FromQuery] string? Name = null, int MaxChildren = 0, int MinChildAge = 0)
        {
            IEnumerable<PlayGround> playGrounds = _playGroundsRepository.GetAll(Name, MaxChildren, MinChildAge);
            if (playGrounds == null)
            {
                return NotFound();
            }
            else if (!playGrounds.Any())
            {
                return NoContent();
            }
            return Ok(playGrounds);

        }

        // GET api/<PlayGroundsRepository>/5
        [HttpGet("{id}")]
        public ActionResult<PlayGround> Get(int id)
        {
            PlayGround? playGrounds = _playGroundsRepository.GetById(id);
            if (playGrounds == null)
            {
                return NotFound();
            }
            return Ok(playGrounds);
        }

        // POST api/<PlayGroundsRepository>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)] // data created
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // bad request
        public ActionResult<PlayGround> Post([FromBody] PlayGround value)
        {
            PlayGround playGrounds = _playGroundsRepository.Add(value);
            return CreatedAtAction(nameof(Get), new { id = playGrounds.Id }, playGrounds);
        }

        // PUT api/<PlayGroundsRepository>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)] // successful update
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // bad request
        [ProducesResponseType(StatusCodes.Status404NotFound)] // not found
        public ActionResult<PlayGround> Put(int id, [FromBody] PlayGround value)
        {
            PlayGround? playGrounds = _playGroundsRepository.Update(id, value);
            if (playGrounds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(playGrounds);
            }
        }

        // DELETE api/<PlayGroundsRepository>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
