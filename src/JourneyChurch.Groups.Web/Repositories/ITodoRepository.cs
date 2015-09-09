using System;
using System.Collections.Generic;
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
}
