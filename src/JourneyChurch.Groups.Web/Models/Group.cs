using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class Group : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Leader { get; set; }
    }

    public class Attendee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMember { get; set; }
        public string Notes { get; set; }
    }

    public class Meeting
    {
        public int Id { get; set; }
        public DateTime MetOn { get; set; }
        public string Notes { get; set; }
    }

    public class MeetingAttendee
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int AttendeeId { get; set; }
        public string Notes { get; set; }
    }
}
