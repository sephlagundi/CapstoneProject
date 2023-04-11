using EMSwebapp.Models;
using EMSwebapp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data;

namespace EMSwebapp.Controllers
{ 


 [Authorize(Roles = "Administrator")]
public class UserController : Controller
{
    private UserManager<ApplicationUser> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }
        public UserController(UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
            _roleManager = roleManager;
        }

        







        // [AllowAnonymous]
        public async Task<IActionResult> GetAllUsersAsync()
    {
            var userViewModel = new List<UserRoleViewModel>();
            var userWithRole = _roleManager.Roles.ToList();

            foreach(var role in userWithRole)
            {
                var userlist = await _userManager.GetUsersInRoleAsync(role.Name);
                foreach (var user in userlist) 
                {
                    userViewModel.Add(new UserRoleViewModel
                    {
                        userId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        roleName = role.Name,
                    });
                }
            }
        
        return View(userViewModel);
    }
    public IActionResult Details(string userId)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
        return View(user);
    }
    public async Task<IActionResult> Delete(string userId)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
        var userlist = await _userManager.DeleteAsync(user);
        return RedirectToAction(controllerName: "User", actionName: "GetAllUsers"); // reload the getall page it self
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(RegisterUserViewModel userViewModel) // model binded this where the views data is accepted 
    {
        if (ModelState.IsValid)
        {
            var userModel = new ApplicationUser
            {
                UserName = userViewModel.Email,
                Email = userViewModel.Email,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName
            };
            var result = await _userManager.CreateAsync(userModel, userViewModel.Password);
            if (result.Succeeded)
            {
                // notify user created

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        return View(userViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Update(string userId)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);
        var roles = await _userManager.GetRolesAsync(user);
        EditUserViewModel userViewModel = new EditUserViewModel()
        {
            FirstName = user.FirstName,
            Email = user.Email,
            LastName = user.LastName,
            Roles = roles
        };
        return View(userViewModel);
    }
    [HttpPost]
    public IActionResult Update(EditUserViewModel user)
    {
        //var user = _userManager.Users.FirstOrDefault(u => u.Id == newUser);

        return RedirectToAction("GetAllUsers");
    }




    }
}
