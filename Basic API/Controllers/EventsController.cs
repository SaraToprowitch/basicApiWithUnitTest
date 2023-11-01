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
        private static List<Event> events;
        private int counter;
        public EventsController()
        {
            events = new List<Event>();

            events.Add(new Event { Id = 1, Title = "Event 1", Start = new DateOnly(2023, 10, 15) });
            events.Add(new Event { Id = 2, Title = "Event 2", Start = new DateOnly(2023, 10, 16) });
            events.Add(new Event { Id = 3, Title = "Event 3", Start = new DateOnly(2023, 10, 17) });

            counter = 4;
        }
      
        // GET: api/<EventsController>
        [HttpGet]
        public  IEnumerable<Event> Get()
        {
            return events;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post(DateOnly date, string value)
        {
            events.Add(new Event { Id = counter++, Title = value, Start = date });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, DateOnly date, string value)
        {
            Event index = events.Find(e => e.Id == id);
            index.Title=value;
            index.Start = date;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var index = events.Find(e => e.Id == id);
            events.Remove(index);
        }
    }
}
