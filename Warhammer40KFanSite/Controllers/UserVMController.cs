using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Controllers;

[Authorize(Roles = "Admin")]
public class UserVmController : Controller
{
    private readonly UserManager<AppUser> _userManager; 
    private readonly RoleManager<IdentityRole> _roleManager;
    
    public UserVmController(UserManager<AppUser> userMngr, RoleManager<IdentityRole> roleMngr)
    {
        _userManager = userMngr; _roleManager = roleMngr;
    }
    
    public async Task<IActionResult> Index() {
        List<AppUser> users = new List<AppUser>(); 
        foreach (AppUser user in _userManager.Users) {
            user.RoleNames = await _userManager.GetRolesAsync(user); users.Add(user);
        }
        
        UserVM model = new UserVM() 
        {
            Users = users, Roles = _roleManager.Roles 
        }; 
        
        return View("Index", model); 
    } 

    [HttpGet]
    public IActionResult Add()
    {
        return View("../RegisterVm/Register");
    }

    [HttpPost]
    public async Task<IActionResult> Add(RegisterVm model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser { UserName = model.Username };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        
        return View("../RegisterVM/Register", model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        AppUser user = await _userManager.FindByIdAsync(id); 
        if (user != null)
        {
            IdentityResult result = await _userManager.DeleteAsync(user); 
            if (!result.Succeeded)
            { // if failed
                string errorMessage = "";
                foreach (IdentityError error in result.Errors)
                {
                    errorMessage += error.Description + " | ";
                }
                TempData["message"] = errorMessage;
            }
        }
        return RedirectToAction("Index");
    }
    
    //Role Management
    [HttpPost]
    public async Task<IActionResult> AddToAdmin(string id)
    {
        IdentityRole adminRole = await _roleManager.FindByNameAsync("Admin");
        if (adminRole == null)
        {
            TempData["Message"] = "Admin role does not exist. "
                                  + "Click 'Create Admin Role' button to create it.";
        }
        else
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, adminRole.Name);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromAdmin(string id)
    {
        AppUser user = await _userManager.FindByIdAsync(id);
        await _userManager.RemoveFromRoleAsync(user, "Admin");
        
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteRole(string id)
    {
        IdentityRole role = await _roleManager.FindByIdAsync(id);
        await _roleManager.DeleteAsync(role);
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdminRole()
    {
        await _roleManager.CreateAsync(new IdentityRole("Admin"));
        
        return RedirectToAction("Index");
    }
}