using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class Report : IHasId
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
    }
}
