using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class ReportAttendee : IHasId
    {
        public ReportAttendee() {
            Notes = "";
        }

        public int Id { get; set; }
        public int AttendeeId { get; set; }
        public int ReportId { get; set; }
        public string Notes { get; set; }
    }
}