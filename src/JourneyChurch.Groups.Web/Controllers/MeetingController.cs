using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Mvc;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class MeetingController : BaseRest<Meeting>
    {
        public MeetingController(IMeetingRepository repository) : base(repository) {
            
        }
    }
}