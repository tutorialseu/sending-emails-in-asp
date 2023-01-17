using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SendingEmailsInASP.Models;

namespace SendingEmailsInASP.Controllers;

public class HomeController : Controller
{
    private readonly IEmailSender emailSender;

    public HomeController(IEmailSender emailSender)
    {
        this.emailSender = emailSender;
    }

    [HttpPost]
    public async Task<IActionResult> Index(string email, string subject, string message)
    {
        await emailSender.SendEmailAsync(email, subject, message);
        return View();
    }

    public IActionResult Index()
    {
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
