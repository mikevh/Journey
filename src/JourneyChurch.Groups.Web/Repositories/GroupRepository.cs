using System.Collections.Generic;
using System.Linq;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.ViewModels.Group;

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

        public IEnumerable<LatestReport> LatestReport() {

            var leader_name_dictionary = DB.Leaders.ToDictionary(l => l.Id, l => l.Name);

            var reports = DB.Groups.Select(g => new LatestReport {
                GroupName = g.Name,
                GroupId = g.Id,
                LeaderId = g.LeaderId ?? 0
            }).ToList();

            reports.ToList().ForEach(r => {
                string name;
                if (leader_name_dictionary.TryGetValue(r.LeaderId, out name)) {
                    r.Leader = name;
                }
            });

            return reports;
        }
    }
}