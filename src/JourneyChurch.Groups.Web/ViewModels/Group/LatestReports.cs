using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyChurch.Groups.Web.ViewModels.Group
{
    public class LatestReport
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int LeaderId { get; set; }
        public string Leader { get; set; }
        public int LatestReportId { get; set; }
        public DateTime LatestReportDate { get; set; }
        public int NeighborhoodId { get; set; }
        public string Neighborhood { get; set; }
        public int Attendance { get; set; }
        public double AvgAttendance { get; set; }
    }
}
