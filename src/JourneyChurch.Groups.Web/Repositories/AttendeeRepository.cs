using JourneyChurch.Groups.Web.Models;

namespace JourneyChurch.Groups.Web.Repositories
{
    public interface IAttendeeRepository : IRepository<Attendee>
    {

    }

    public class AttendeeRepository : Repository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(DB db) : base(db) {
            
        }
    }
}