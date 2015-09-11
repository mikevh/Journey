using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class MeetingAttendee : IHasId
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int AttendeeId { get; set; }
        public string Notes { get; set; }
    }
}