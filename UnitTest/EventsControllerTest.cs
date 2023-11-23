using Basic_API;
using Basic_API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest
{
    public class EventsControllerTest
    {
        private readonly EventsController eventsController;
        private readonly Event events;
        public EventsControllerTest()
        {
            var context = new DataContextFake();
            eventsController = new EventsController(context);
            events = new Event() { Id = 4, Title = "dfghjk" };
        }

        [Fact]
        public void Test1()
        {
            var result = eventsController.Get();
            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void GetById_ReturnOk()
        {
            var id = 1;
            var result = eventsController.Get(id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void postById_ReturnNotFound()
        {
            var id = 3;
            var result = eventsController.Post(events);
            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public void deleteById_ReturnNotFound()
        {
            var id = 3;
            var result = eventsController.Delete(id);
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void putById_ReturnNotFound()
        {
            var id = 3;
            var result = eventsController.Put(id,events);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
    
}