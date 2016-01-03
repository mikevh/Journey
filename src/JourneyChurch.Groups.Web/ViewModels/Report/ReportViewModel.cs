using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;

namespace JourneyChurch.Groups.Web.ViewModels.Report
{
    public class ReportViewModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public IEnumerable<AttendeeViewModel> Attendees { get; set; }
    }
}
