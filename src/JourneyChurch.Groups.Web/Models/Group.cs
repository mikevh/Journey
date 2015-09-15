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
        public DayOfWeek MeetsOn { get; set; }
        public DateTime MeetsAt { get; set; }
    }
}
