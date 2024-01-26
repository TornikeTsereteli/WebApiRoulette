using Microsoft.AspNetCore.Mvc;

namespace WebApplication9.Controllers;
using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    // GET: /Home/Index
    [HttpGet("Index")]
    public IActionResult Index()
    {
        // Return HTML page with input and button
        string htmlContent =
            System.IO.File.ReadAllText(
                "C:\\Users\\WERO\\RiderProjects\\WebApplication9\\WebApplication9\\View\\Home\\makeBet.html");
        
        return Content(htmlContent,"text/html");
    }

    // GET: /Home/RedirectPage
    [HttpGet("StartGame")]
    public IActionResult StartGame(string inputValue)
    {
        string htmlContent = System.IO.File.ReadAllText(
            "C:\\Users\\WERO\\RiderProjects\\WebApplication9\\WebApplication9\\View\\Home\\GameStartFile.html");
        return Content(htmlContent, "text/html");
    }
}
