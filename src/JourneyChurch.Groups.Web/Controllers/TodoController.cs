using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;

        // todo: use view models
        public TodoController(ITodoRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll() {
            var rv = _repository.All;
            return rv;
        }

        [HttpGet("{id:int}", Name = "GetByIdRoute")]
        public IActionResult GetById(int id) {
            var item = _repository.Get(id);
            if (item == null) {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreateTodoItem([FromBody] TodoItem item)
        {
            if (!ModelState.IsValid) {
                return new HttpStatusCodeResult(400);
            }
            _repository.Add(item);

            string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                Request.Scheme, Request.Host.ToUriComponent());

            Context.Response.StatusCode = 201;
            Context.Response.Headers["Location"] = url;
            return new ObjectResult(item);
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (_repository.Delete(id)) {
                return new HttpStatusCodeResult(204);
            }

            return HttpNotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]TodoItem item) {
            _repository.Update(item);
            return new ObjectResult(item);
        }
    }
}
