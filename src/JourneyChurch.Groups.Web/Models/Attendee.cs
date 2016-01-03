using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class Attendee : IHasId
    {
        public Attendee() {
            Name = "";
            Notes = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMember { get; set; }
        public string Notes { get; set; }
    }
}