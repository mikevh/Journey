using System.ComponentModel.DataAnnotations;

namespace JourneyChurch.Groups.Web.ViewModels.User
{
    public class UpdatePasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Password { get; set; }
    }
}