using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;

namespace JourneyChurch.Groups.Web.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }

    public static class Extentions
    {
        public static IQueryable<UserViewModel> ToViewModel(this IQueryable<JourneyUser> user, IList<JourneyUser> administrators = null) {
            return user.Select(u => ToViewModel(u, administrators));
        }

        public static UserViewModel ToViewModel(this JourneyUser user, IList<JourneyUser> administrators = null) {
            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                IsAdmin = administrators != null && administrators.Contains(user)
            };
        }
    }
}
