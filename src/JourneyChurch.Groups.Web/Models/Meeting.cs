using System;
using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class Meeting : IHasId
    {
        public int Id { get; set; }
        public DateTime MetOn { get; set; }
        public string Notes { get; set; }
    }
}