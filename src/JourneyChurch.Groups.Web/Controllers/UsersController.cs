using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.ViewModels.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserManager<JourneyUser> _userManager;

        public UsersController(UserManager<JourneyUser> userManager) {
            _userManager = userManager;

            if (!_userManager.Users.Any()) {

                var admin = _userManager.CreateAsync(new JourneyUser {UserName = "admin", Email = "mikevh@gmail.com"}).Result;
            }
        }

        [HttpGet]
        public IActionResult GetAll() {
            var rv = _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            });

            return new ObjectResult(rv);
        }
    }
}
