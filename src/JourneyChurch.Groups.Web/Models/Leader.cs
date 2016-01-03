using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Repositories;

namespace JourneyChurch.Groups.Web.Models
{
    public class Leader : IHasId
    {
        public Leader() {
            Name = "";
            Email = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
