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


        public UsersController(UserManager<JourneyUser> userManager, RoleManager<IdentityRole> roleManager) {
            _roleManager = roleManager;
            _userManager = userManager;

            if (!_roleManager.Roles.Any()) {
                _roleManager.CreateAsync(new IdentityRole("Administrator")).Wait();
            }

            //if (!_userManager.Users.Any()) {
                
            //    _userManager.CreateAsync(new JourneyUser {UserName = "admin", Email = "mikevh@gmail.com"}).Wait();
            //    var admin = _userManager.FindByNameAsync("admin").Result;
            //    _userManager.AddToRoleAsync(admin, "Administrator").Wait();
            //}
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) {
            var item = await _userManager.FindByIdAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            
            }
            var adminstrators = await _userManager.GetUsersInRoleAsync("Administrator");
            var rv = item.ToViewModel(adminstrators);
            return new ObjectResult(rv);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var adminstrators = await _userManager.GetUsersInRoleAsync("Administrator");

            var rv = _userManager.Users.ToViewModel(adminstrators);
            return new ObjectResult(rv);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel item) {
            var user = new JourneyUser {UserName = item.UserName, Email = item.Email};
            var result = await _userManager.CreateAsync(user, item.ResetPassword);

            var ok = await _userManager.CheckPasswordAsync(user, "Pass@word2");

            if (item.UserName.StartsWith("admin")) {
                await _userManager.AddToRoleAsync(user, "Administrator");
            }

            var url = Url.RouteUrl("GetByIdRoute", new { id = item.Id }, Request.Scheme, Request.Host.ToUriComponent());
            Response.StatusCode = 201;
            Response.Headers["Location"] = url;
            return new ObjectResult(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody]UserViewModel item) {
            var user = await _userManager.FindByIdAsync(id);
            var adminstrators = await _userManager.GetUsersInRoleAsync("Administrator");

            if (item.IsAdmin == false && adminstrators.Contains(user)) {
                await _userManager.RemoveFromRoleAsync(user, "Administrator");
            }
            else if (item.IsAdmin && !adminstrators.Contains(user)) {
                await _userManager.AddToRoleAsync(user, "Administrator");
            }
            user.Email = item.Email;
            user.UserName = item.UserName;

            if (item.ResetPassword != null) {
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, item.ResetPassword);
            }

            await _userManager.UpdateAsync(user);

            return await GetById(id);
        }
    }
}
