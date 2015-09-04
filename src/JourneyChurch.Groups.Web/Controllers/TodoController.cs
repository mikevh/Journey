using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Mvc;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll() {
            return _repository.All;
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
        public void CreateTodoItem([FromBody] TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _repository.Add(item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id },
                    Request.Scheme, Request.Host.ToUriComponent());

                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (_repository.Delete(id)) {
                return new HttpStatusCodeResult(204);
            }

            return HttpNotFound();
        }
    }
}
