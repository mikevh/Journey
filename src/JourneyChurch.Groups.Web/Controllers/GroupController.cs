using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Mvc;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : BaseRest<Group>
    {
        public GroupController(IGroupRepository repository) : base(repository){
            
        }
    }
}