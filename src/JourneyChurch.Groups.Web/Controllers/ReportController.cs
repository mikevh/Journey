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
        private readonly IReportAttendeeRepository _report_attendee_repository;

        public ReportController(IReportRepository report_repository, IAttendeeRepository attendee_repository, IReportAttendeeRepository report_attendee_repository) : base(report_repository) {
            _report_attendee_repository = report_attendee_repository;
            _attendee_repository = attendee_repository;
            _report_repository = report_repository;
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult Post([FromBody] ReportViewModel model) {

            var report = new Report {
                Date = model.Date,
                GroupId = model.GroupId
            };

            _report_repository.Upsert(report);

            model.Id = report.Id;

            foreach (var avm in model.Attendees) {
                var attendee = new Attendee {
                    Id = avm.AttendeeId,
                    Name = avm.Name
                };
                _attendee_repository.Upsert(attendee);


                var report_attendee = new ReportAttendee {
                    AttendeeId = attendee.Id,
                    ReportId = report.Id,
                };
                _report_attendee_repository.Upsert(report_attendee);
            }

            return new ObjectResult(model);
        }
    }
}
