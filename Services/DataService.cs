using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbcontext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbcontext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            //Create the DB from the Migration
            await _dbContext.Database.MigrateAsync();

            // Task 1: Seed a few roles into the system
            await SeedRolesAsync();

            // Task 2: Seed a few users into the system
            await SeedUsersAsync();

        }

        private async Task SeedRolesAsync()
        {
            // If there are already Roles in the system, do nothing.

            if (_dbContext.Roles.Any()) return;

            // Otherwise we want to create a few Roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the Role Manager to create Roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }


        private async Task SeedUsersAsync()
        {
            // If there are already users in the system, do nothing.

            if (_dbContext.Users.Any())
            {
                return;
            }


            // Step 1: Creates a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "austinbruso@hotmail.com",
                UserName = "austinbruso@hotmail.com",
                FirstName = "Austin",
                LastName = "Bruso",
                DisplayName = "Developer",
                EmailConfirmed = true
            };


            // Step 2: Use the UserManager to create a new user that is defined by a admin Manager

            await _userManager.CreateAsync(adminUser, "Abc&123!");


            // Step 3: Add the new user to the Administrator Role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());


            //Stp 4: Create a Moderator User

            var modUser = new BlogUser()
            {

                Email = "JaneDoe@mailinator.com",
                UserName = "JaneDoe@mailinator.com",
                FirstName = "Jane",
                LastName = "Doe",
                DisplayName = "The Other Developer",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(modUser, "Abc&123!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());


        }



    }
}
