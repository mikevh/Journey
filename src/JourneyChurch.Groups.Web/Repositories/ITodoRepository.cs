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
        void Update(TodoItem item);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly Dictionary<int, TodoItem> _items = new Dictionary<int,TodoItem>();
        private int _identity = 0;

        public TodoRepository()
        {
            Add(new TodoItem {Title = "hello"});
        }

        public IEnumerable<TodoItem> All => _items.Values;

        public void Add(TodoItem item) {
            item.Id = ++_identity;
            _items[item.Id] = item;
        }

        public TodoItem Get(int id) {
            return _items[id];
        }

        public bool Delete(int id) {
            var item = Get(id);
            if (item == null) {
                return false;
            }
            _items.Remove(id);
            return true;
        }

        public void Update(TodoItem item) {
            _items[item.Id] = item;
        }
    }
}
