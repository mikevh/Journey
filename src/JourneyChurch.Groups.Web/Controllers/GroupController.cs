using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.Repositories;
using Microsoft.AspNet.Mvc;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : BaseRest<Group>
    {
        private readonly IGroupRepository _group_repository;

        public GroupController(IGroupRepository repository) : base(repository) {
            _group_repository = repository;
        }

        [Route("[action]")]
        public IActionResult GetLatestReports() {

            var reports = _group_repository.LatestReport();

            return new ObjectResult(reports);
        }
    }
}