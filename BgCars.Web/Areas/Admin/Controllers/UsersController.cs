namespace BgCars.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Users;
    using Services.Interfaces;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService users;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(IAdminUserService users,
                               UserManager<User> userManager,
                               RoleManager<IdentityRole> roleManager)
        {
            this.users = users;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        //GET: /admin/users/
        public async Task<IActionResult> Index()
        {
            var users = await this.users.AllAsync();
            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            return View(new UserListingsViewModel
            {
                Users = users,
                Roles = roles
            });
        }


        //POST: /admin/users/AddToRole
        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            TempData.AddSuccessMessage($"User {user.UserName} successfully added to the {model.Role} role.");
            return RedirectToAction(nameof(Index));
        }

        //GET: /Admin/Users/DeleteUser/{id}
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var findUser = await this.userManager.FindByIdAsync(userId);

            if (findUser == null)
            {
                return NotFound();
            }

            return View(new UserDeleteForm
            {
                Id = findUser.Id,
                Name = findUser.Name,
                Username = findUser.UserName,
                Birthdate = findUser.Birthdate,
                Email = findUser.Email
            });
        }

        //POST: /Admin/Users/DeleteUser/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var findUserById = await this.userManager.FindByIdAsync(id);

            if (findUserById == null)
            {
                return NotFound();
            }

            await this.users.DeleteAsync(findUserById.Id);

            TempData.AddSuccessMessage($"User {findUserById.UserName} successfully deleted ");

            return RedirectToAction(nameof(Index));
        }
    }
}
