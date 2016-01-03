using JourneyChurch.Groups.Web.Models;

namespace JourneyChurch.Groups.Web.Repositories
{
    public interface IReportRepository : IRepository<Report>
    {

    }

    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(DB db) : base(db) {
            
        }
    }
}