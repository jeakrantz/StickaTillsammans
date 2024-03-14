using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StickaTillsammans.Models;
using StickaTillsammans.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;

namespace StickaTillsammans.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    /*     public IActionResult Index()
        {
            return View();
        } */

    public async Task<IActionResult> Index()
    {
        var dataCourse = _context.Courses.Include(_ => _.Participants).ToListAsync();
        return View(await dataCourse);
    }
    public IActionResult Offers()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }

    public async Task<IActionResult> About()
    {
        var dataPost = _context.Posts.Include(p => p.Category).ToListAsync();
        return View(await dataPost);
    }

    public ActionResult RedirectBuissness()
    {
        return Redirect(Url.Action("Offers", "Home") + "#Buisness");
    }
    
    public ActionResult RedirectGiftCard()
    {
        return Redirect(Url.Action("Offers", "Home") + "#GiftCard");
    }
    public ActionResult RedirectMembership()
    {
        return Redirect(Url.Action("Offers", "Home") + "#Membership");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
