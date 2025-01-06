using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Warhammer40KFanSite.Models;

namespace Warhammer40KFanSite.Controllers;

public class SourcesController : Controller
{
    private readonly ILogger<SourcesController> _logger;

    public SourcesController(ILogger<SourcesController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult FanSites()
    {
        return View();
    }
    
    public IActionResult News()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}