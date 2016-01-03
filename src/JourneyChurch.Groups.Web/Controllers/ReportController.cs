using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.Repositories;
using JourneyChurch.Groups.Web.ViewModels.Report;
using Microsoft.AspNet.Mvc;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : BaseRest<Report>
    {
        private readonly IReportRepository _report_repository;
        private readonly IAttendeeRepository _attendee_repository;

        public ReportController(IReportRepository report_repository, IAttendeeRepository attendee_repository) : base(report_repository) {
            _attendee_repository = attendee_repository;
            _report_repository = report_repository;
        }

        [Route("[action]")]
        public IActionResult Post([FromBody] ReportViewModel model) {

            var report = new Report {
                Date = model.Date,
                GroupId = model.GroupId
            };

            _report_repository.Upsert(report);

            model.Id = report.Id;

            return new ObjectResult(model);
        }
    }
}
