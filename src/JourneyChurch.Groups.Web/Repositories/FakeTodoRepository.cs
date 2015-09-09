using System.Collections.Generic;
using JourneyChurch.Groups.Web.Models;

namespace JourneyChurch.Groups.Web.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        private readonly Dictionary<int, TodoItem> _items = new Dictionary<int,TodoItem>();
        private int _identity = 0;

        public FakeTodoRepository()
        {
            Add(new TodoItem {Title = "hello"});
            Add(new TodoItem {Title = "foobar"});
            
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