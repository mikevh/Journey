﻿using System;
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
            var user = new JourneyUser {
                UserName = item.UserName,
                Email = item.Email
            };
            var result = await _userManager.CreateAsync(user, item.Password);

            if (item.IsAdministrator) {
                await _userManager.AddToRoleAsync(user, "Administrator");
            }

            var url = Url.RouteUrl("GetByIdRoute", new { id = item.Id }, Request.Scheme, Request.Host.ToUriComponent());
            Response.StatusCode = 201;
            Response.Headers["Location"] = url;
            return new ObjectResult(item);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdatePassword(string id, [FromBody]UpdatePasswordViewModel vm) {
            if (!ModelState.IsValid) {
                var errorMessage = ModelState["Password"].Errors.First().ErrorMessage;
                return HttpBadRequest(errorMessage);
            }
            var user = await _userManager.FindByIdAsync(id);
            if(user == null) {
                return HttpNotFound(); 
            }
            if(!string.IsNullOrWhiteSpace(vm.Password)) {
                await _userManager.RemovePasswordAsync(user);
                var result = _userManager.AddPasswordAsync(user, vm.Password);
                if (result.Result == IdentityResult.Success) {
                    return new HttpOkResult();
                }
                var error = result.Result.Errors.First().Description;
                return HttpBadRequest(error);
            }
            return HttpBadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody]UserViewModel item) {
            if (id == "0") {
                return await Create(item);
            }

            var user = await _userManager.FindByIdAsync(id);
            var adminstrators = await _userManager.GetUsersInRoleAsync("Administrator");

            if (item.IsAdministrator == false && adminstrators.Contains(user)) {
                await _userManager.RemoveFromRoleAsync(user, "Administrator");
            }
            else if (item.IsAdministrator && !adminstrators.Contains(user)) {
                await _userManager.AddToRoleAsync(user, "Administrator");
            }
            user.Email = item.Email;
            user.UserName = item.UserName;

            await _userManager.UpdateAsync(user);

            return await GetById(id);
        }
    }
}
