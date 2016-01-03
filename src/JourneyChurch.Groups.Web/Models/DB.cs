using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Models
{
    public class DB : IdentityDbContext<JourneyUser>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportAttendee> ReportAttendees { get; set; } 
    }
}
