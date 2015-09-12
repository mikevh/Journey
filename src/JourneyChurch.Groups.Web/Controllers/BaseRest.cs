using System.Linq;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Mvc;

namespace JourneyChurch.Groups.Web.Controllers
{
    public abstract class BaseRest<T> : Controller where T : class, IHasId
    {
        private readonly IRepository<T> _repository;

        protected BaseRest(IRepository<T> repository) {
            _repository = repository;
        }

        [HttpGet]
        public IQueryable<T> GetAll() {
            return _repository.All;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var item = _repository.Find(id);
            if (item == null) {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreateTodoItem([FromBody] T item) {
            if (!ModelState.IsValid) {
                return new HttpStatusCodeResult(400);
            }
            _repository.Upsert(item);

            var url = Url.RouteUrl("GetByIdRoute", new { id = item.Id }, Request.Scheme, Request.Host.ToUriComponent());
            Context.Response.StatusCode = 201;
            Context.Response.Headers["Location"] = url;
            return new ObjectResult(item);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id) {
            if (_repository.Delete(id)) {
                return new HttpStatusCodeResult(204);
            }

            return HttpNotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]T item) {
            _repository.Upsert(item);
            return new ObjectResult(item);
        }
    }
}