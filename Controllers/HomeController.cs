using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DIUN_dotnet_mvc_statuspage.Models;


namespace DIUN_dotnet_mvc_statuspage.Controllers;

public class HomeController : Controller
{
    private readonly MvcDiunUpdateContext _context;


    public HomeController(MvcDiunUpdateContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(await ApiController.Index());
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
