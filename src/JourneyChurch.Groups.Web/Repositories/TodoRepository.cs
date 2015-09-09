using System.Collections.Generic;
using System.Linq;
using JourneyChurch.Groups.Web.Models;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private DB _db;

        public TodoRepository(DB db) {
            _db = db;
        }

        public IEnumerable<TodoItem> All => _db.Todos;

        public void Add(TodoItem item) {
            _db.Todos.Add(item);
            _db.SaveChanges();
        }

        public TodoItem Get(int id) {
            var rv = _db.Todos.FirstOrDefault(t => t.Id == id);
            return rv;
        }

        public bool Delete(int id) {
            var todo = Get(id);
            if (todo != null) {
                _db.Todos.Remove(todo);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(TodoItem item) {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}