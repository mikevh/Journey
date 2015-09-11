using System.Collections.Generic;
using System.Linq;
using JourneyChurch.Groups.Web.Models;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Repositories
{
    public class TodoRepository : Repository<TodoItem>, ITodoRepository
    {
        public TodoRepository(DB db) : base(db) {
        }
    }
}