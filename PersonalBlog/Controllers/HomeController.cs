using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalBlog.Interface;
using PersonalBlog.Models;
using PersonalBlog.Strategies;

namespace PersonalBlog.Controllers;

public class HomeController(IDataService dataService, ILogger<HomeController> logger) : Controller
{
    private readonly ILogger _logger = logger;

    [Route("/")]
    public async Task<IActionResult> Index()
    {
        var allRows = await dataService.GetAll();
        return View(allRows);
    }

    [Route("Post")]
    [HttpGet]
    [ServiceFilter(typeof(ProtectorAttribute))]
    public IActionResult CreatePost(Post model)
    {
        return View(model);
    }

    [HttpPost]
    [Route("Post")]
    [ServiceFilter(typeof(ProtectorAttribute))]
    public async Task<IActionResult> Post(Post model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("Validation", "Please provide all values");
            return View("CreatePost", model);
        }

        await dataService.Create(model);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}