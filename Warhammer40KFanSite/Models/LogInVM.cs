using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Warhammer40KFanSite.Models;

public class LogInVM
{
    [Required(ErrorMessage = "Please enter a username.")] [StringLength(255)]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Please enter a password.")] [StringLength(255)]
    public string Password { get; set; } 
    
    [ValidateNever]
    public string ReturnUrl { get; set; } 
    public bool RememberMe { get; set; }
}