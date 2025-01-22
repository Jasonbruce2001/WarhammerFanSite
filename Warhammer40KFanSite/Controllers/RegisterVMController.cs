using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Interfaces;
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
    
    [HttpGet]
    public IActionResult LogIn(string returnURL = "")
    {
        var model = new LogInVM { ReturnUrl = returnURL };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LogInVM model)
    {
        model.ReturnUrl = "";
        if (ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync
                (model.Username, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                    Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        ModelState.AddModelError(string.Empty, "Invalid username or password.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}