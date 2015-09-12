using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : BaseRest<TodoItem>
    {
        public TodoController(ITodoRepository repository) : base(repository) {
            
        }
    }
}
