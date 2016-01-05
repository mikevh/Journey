using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.ViewModels.Group;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<LatestReport> LatestReport();
    }

    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DB db) : base(db) {
            
        }

        private void Foo() {

        }

        public IEnumerable<LatestReport> LatestReport() {

//            var q = @"

//WITH cte AS(
//    SELECT Id, ROW_NUMBER() OVER(PARTITION BY GroupId ORDER BY [Date] DESC) latest
//    FROM Report
//)
//SELECT
//r.Id LatestReportId,
//r.[Date] LatestReportDate,
//g.id GroupId,
//g.Name GroupName,
//l.Id LeaderId,
//l.Name Leader,
//0 Attendance,
//0 AvgAttendance,
//0 NeighborhoodId,
//'' Neighborhood
//FROM [Group] g
//LEFT JOIN Report r ON r.GroupId = g.Id
//LEFT JOIN cte ON r.Id = cte.Id
//LEFT JOIN Leader l ON l.Id = g.LeaderId
//WHERE cte.latest IS NULL OR cte.latest = 1	
	
//";
            var z = DB.Set<LatestReport>().FromSql("select * from vw_latestreports").ToList();

            return z;

            //var result = DB.Groups.FromSql(q).ToList();

            //var query = from g in DB.Groups
            //    join l in DB.Leaders
            //        on g.LeaderId equals l.Id
            //        into lg
            //    join r in DB.Reports on g.Id equals r.GroupId into rg
            //    let rx = rg.Max(x => x.Date)
            //    from x in lg.DefaultIfEmpty()
            //    select LatestReport(g, x);

            //var ql = query.ToList();

            //return ql;
        }

        //private LatestReport LatestReport(Group g, Leader x)
        //{
        //    return new LatestReport
        //    {
        //        Leader = x == null ? "" : x.Name,
        //        LeaderId = x == null ? 0 : x.Id,
        //        GroupId = g.Id,
        //        GroupName = g.Name,
        //    };
        //}
    }
}