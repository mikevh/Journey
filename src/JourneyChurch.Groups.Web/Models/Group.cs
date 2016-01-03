using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class Group : IHasId
    {
        public Group() {
            Name = "";
            MeetsAt = "";
            Notes = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MeetsOn { get; set; }
        public string MeetsAt { get; set; }
        public string Notes { get; set; }
        public int? LeaderId { get; set; }
    }
}
