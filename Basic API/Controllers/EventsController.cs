using Basic_API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Metrics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Basic_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private int counter=4;
        private IDataContext dataContext;

        public EventsController(IDataContext context)
        {
            dataContext = context;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public  IActionResult Get()
        {
            return Ok(dataContext.EventList);
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var eve = dataContext.EventList.Find(e => e.Id == id);
            if (eve == null)
            {
                return NotFound();
            }
            return Ok(eve);
        }

        // POST api/<EventsController>
        [HttpPost]
        public IActionResult Post([FromBody] Event newEvent)
        {
            dataContext.EventList.Add(new Event { Id = 2, Title = newEvent.Title });
            return BadRequest(dataContext.EventList);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event updateEvent)
        {
            var eve = dataContext.EventList.Find(e => e.Id == id);
            if(eve == null)
            {
               return NotFound(eve);
            }
            eve.Title = updateEvent.Title;
            return Ok(eve);
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = dataContext.EventList.Find(e => e.Id == id);
            dataContext.EventList.Remove(index);
            return NoContent();
        }
    }
}