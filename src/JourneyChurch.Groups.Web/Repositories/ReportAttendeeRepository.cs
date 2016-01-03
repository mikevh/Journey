using JourneyChurch.Groups.Web.Models;

namespace JourneyChurch.Groups.Web.Repositories
{
    public interface IReportAttendeeRepository : IRepository<ReportAttendee>
    {

    }

    public class ReportAttendeeRepository : Repository<ReportAttendee>, IReportAttendeeRepository
    {
        public ReportAttendeeRepository(DB db) : base(db) {
            
        }
    }
}