using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;

namespace JourneyChurch.Groups.Web.Models
{
    public class DB : IdentityDbContext<JourneyUser>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportAttendee> ReportAttendees { get; set; } 
        public DbSet<Attendee> Attendees { get; set; }
    }

    public static class DBSeed
    {
        public static void EnsureSeedData(this DB context) {
            if (context.AllMigrationsApplied()) {
                if (!context.Leaders.Any()) {
                    var leader = new Leader {Name = "Bill", Email = "bill@sullivan.com"};
                    context.Leaders.Add(leader);
                    context.SaveChanges();
                    var group = new Group {Name = "packers", LeaderId = leader.Id, MeetsAt = "18:00:00", MeetsOn = 4, Notes = "foo"};
                    context.Groups.Add(group);
                    context.SaveChanges();
                }
            }
        }

        public static bool AllMigrationsApplied(this DbContext context) {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);
            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);
            return !total.Except(applied).Any();
        }
    }
}
