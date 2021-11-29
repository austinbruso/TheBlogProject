using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogProject.Data;

namespace TheBlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbcontext;

        public DataService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
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
            foreach(var role in Enum.GetNames(Type
        }


        private async Task SeedUserAsync()
        {

        }



    }
}
