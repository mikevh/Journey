using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyChurch.Groups.Web.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
