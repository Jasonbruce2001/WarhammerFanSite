using System.ComponentModel.DataAnnotations;

namespace Warhammer40KFanSite.Models;

public class RegisterVm
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(255)]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [Compare("ConfirmPassword")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Please confirm your password.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    public string ConfirmPassword { get; set; }
}