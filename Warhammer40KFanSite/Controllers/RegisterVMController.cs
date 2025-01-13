using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Controllers;

public class RegisterVmController : Controller
{
    private UserManager<AppUser> userManager; 
    private SignInManager<AppUser> signInManager;
    public RegisterVmController(UserManager<AppUser> userMngr, SignInManager<AppUser> signInMngr)
    {
        userManager = userMngr; signInManager = signInMngr;
    } 
    
    // GET
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVm model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser() { UserName = model.Username };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        
        return View(model);
    }

}