using System;
using System.Collections.Generic;
using System.Linq;
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

        public override IActionResult Post([FromBody]Meeting item) {
            item.MetOn = DateTime.Now;
            return base.Post(item);
        }

        [Route("[action]/{id}")]
        public IEnumerable<Meeting> GetPrevousReportsForGroup(int id) {
            return _repository.Set.Where(x => x.GroupId == id).OrderByDescending(x => x.MetOn);
        }
    }
}