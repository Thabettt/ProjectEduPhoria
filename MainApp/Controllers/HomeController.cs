using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MainApp.Models;
using Microsoft.AspNetCore.Identity;

namespace MainApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        string userRole = "Guest";
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    userRole = "Admin";
                }
                else if (await _userManager.IsInRoleAsync(user, "Learner"))
                {
                    userRole = "Learner";
                }
                else if (await _userManager.IsInRoleAsync(user, "Instructor"))
                {
                    userRole = "Instructor";
                }
            }
        }
        ViewData["UserRole"] = userRole;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}