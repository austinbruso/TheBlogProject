using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogProject.Data;
using TheBlogProject.Enums;
using TheBlogProject.Models;

namespace TheBlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbcontext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbcontext = dbcontext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            await SeedRolesAsync();


            await SeedUserAsync();

        }

        private async Task SeedRolesAsync()
        {
            // If there are already Roles in the system, do nothing.

            if (_dbcontext.Roles.Any()) return;

            // Otherwise we want to create a few Roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the Role Manager to create Roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }


        private async Task SeedUserAsync()
        {
            // If there are already Roles in the system, do nothing.

            if (_dbcontext.Users.Any()) return;


            // Step 1: Creates a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "AustinBruso@Hotmail.com",
                UserName = "AustinBruso@Hotmail.com",
                FirstName = "Austin",
                LastName = "Bruso",
                DisplayName = "The Developer",
                EmailConfirmed = true
            };


            // Step 2: Use the UserManager to create a new user that is defined by a admin Manager

            await _userManager.CreateAsync(adminUser, "Abc1234!");


            // Add the new user to the Administrator Role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());


            //Create a Moderator User

            var modUser = new BlogUser()
            {

                Email = "JaneDoe@mailinator.com",
                UserName = "JaneDoe@mailinator.com",
                FirstName = "Jane",
                LastName = "Doe",
                DisplayName = "The Developer",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(modUser, "Abc1234!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());


        }



    }
}
