using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Controllers;

public class BookClubController : Controller
{
    private readonly ILogger<BookClubController> _logger;

    public BookClubController(ILogger<BookClubController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Recommendations()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}