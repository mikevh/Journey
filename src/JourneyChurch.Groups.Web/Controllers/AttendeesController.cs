using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JourneyChurch.Groups.Web.Models;
using JourneyChurch.Groups.Web.ViewModels.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace JourneyChurch.Groups.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserManager<JourneyUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<JourneyUser> userManager, RoleManager<IdentityRole> roleManager  ) {
            _roleManager = roleManager;
            _userManager = userManager;

            if (!_roleManager.Roles.Any()) {
                _roleManager.CreateAsync(new IdentityRole("Administrator")).Wait();
            }

            if (!_userManager.Users.Any()) {
                
                _userManager.CreateAsync(new JourneyUser {UserName = "admin", Email = "mikevh@gmail.com"}).Wait();
                var admin = _userManager.FindByNameAsync("admin").Result;
                _userManager.AddToRoleAsync(admin, "Administrator").Wait();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var adminstrators = await _userManager.GetUsersInRoleAsync("Administrator");

            var rv = _userManager.Users.Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                IsAdmin = adminstrators.Contains(u)
            });

            return new ObjectResult(rv);
        }
    }
}
