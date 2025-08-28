using Microsoft.AspNetCore.Mvc;

namespace MVC01.Controllers;

public class BailController : Controller
{
    private readonly ILogger<BailController> _logger;

    public BailController(ILogger<BailController> logger)
    {
        _logger = logger;
    }

    // Action Index() trả ra thời gian hiện hành
    public IActionResult Index()
    {
        var currentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        ViewBag.CurrentTime = currentTime;
        return View();
    }

    // Action Welcome(string name) trả ra "xin chào" + name
    public IActionResult Welcome(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            name = "Khách";
        }

        var welcomeMessage = $"Xin chào {name}";
        ViewBag.WelcomeMessage = welcomeMessage;
        ViewBag.Name = name;
        return View();
    }
}
