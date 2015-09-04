using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;

namespace JourneyChurch.Groups.Web.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> All { get; }
        void Add(TodoItem item);
        TodoItem Get(int id);
        bool Delete(int id);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _items = new List<TodoItem>();
        private int _identity = 0;

        public IEnumerable<TodoItem> All { get { return _items; } }
        public void Add(TodoItem item) {
            item.Id = ++_identity;
            _items.Add(item);
        }

        public TodoItem Get(int id) {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public bool Delete(int id) {
            var item = Get(id);
            if (item == null) {
                return false;
            }
            _items.Remove(item);
            return true;
        }
    }
}
