using System;
using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class Meeting : IHasId
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime MetOn { get; set; }
        public string Notes { get; set; }
        public int Attendance { get; set; }

        public Group Group { get; set; }
    }
}