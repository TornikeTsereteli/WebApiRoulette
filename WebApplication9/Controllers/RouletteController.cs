using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RoulleteGame;
using WebApplication9.Model;

namespace WebApplication9.Controllers;


[ApiController]
[Route("[controller]")]
public class RouletteController:ControllerBase
{

    private readonly RouletteContextDapper _rouletteContextDapper;

    public RouletteController(IConfiguration configuration)
    {
        _rouletteContextDapper = new RouletteContextDapper(configuration);
    }


    [HttpGet("GetPlayers")]
    public IEnumerable<RPlayer> GetPlayers(string t)
    {
        return _rouletteContextDapper.GetPlayers();
    }
    
    [HttpGet("MakeBet")]
    public IActionResult MakeBet(int selectedBet, string betAmount,string userName)
    {
        if (!int.TryParse(betAmount, out int betMoney)) throw new ArgumentException("argument exception");
        RPlayer rPlayer = _rouletteContextDapper.GetPlayer(userName);
        if(rPlayer == null) throw new ArgumentException("NO such username exist");
        if (rPlayer.Balance < 0) throw new ArgumentException("balance is less Than Zeroo!!!");
        Player player = new Player(rPlayer);
        BetType betType = ConcreteBetManager.GetPossibleBets()[selectedBet];
        int luckyNumber = Random.Shared.Next(1,36);
        player.PlaceBet(betMoney,betType);
        string winOrLose = player.ShowWinningMoney(luckyNumber);
        
        // update user properties in database
        if (!_rouletteContextDapper.UpdatePlayerBalance(player.UserName, player.Balance))
            throw new ArgumentException("Problem At Updating Player Balance");
            
        return Content($"<h2>{winOrLose}<h2> " +
                       $"<h2>Game Options</h2>\n" +
                       $"\n<form method='get' action='/Roulette/MakeBetState'>\n  " +
                       $"  <button style='background-color:green;' type='submit'>Play Again</button>" +
                       $"\n</form>\n\n<form method='get' action='/Roulette/StartGame'>\n    " +
                       $"<button style='background-color:green;' type='submit'>End Game</button>\n</form>\n", 
            "text/html" );
    }
    [HttpGet("CreatePlayer")]
    public IActionResult CreatePlayer(string userName, string balance)
    {
        if (!decimal.TryParse(balance, out decimal Balance) && Balance >= 0)
            throw new AggregateException("illegal argument");
        _rouletteContextDapper.InsertPlayer(userName,Balance);
        // must fill with relevant html file  
            
            
        var htmlContent =
            System.IO.File.ReadAllText(
                "C:\\Users\\WERO\\RiderProjects\\WebApplication9\\WebApplication9\\View\\Home\\makeBet.html");
        return Content(htmlContent, "text/html");

    }

    [HttpGet("StartGame")]
    public IActionResult StartGame()
    {
        var htmlContent = System.IO.File.ReadAllText("C:\\Users\\WERO\\RiderProjects\\WebApplication9\\WebApplication9\\View\\Home\\Start.html");
        return Content(htmlContent, "text/html");
    }
    
    [HttpGet("MakeBetState")]
    public IActionResult MakeBetState()
    {
        var htmlContent =
            System.IO.File.ReadAllText(
                "C:\\Users\\WERO\\RiderProjects\\WebApplication9\\WebApplication9\\View\\Home\\makeBet.html");

        return Content(htmlContent, "text/html");
    }
    [HttpGet("CreatePlayerState")]
    public IActionResult CreatePlayerState()
    {
        var htmlContent = System.IO.File.ReadAllText(
            "C:\\Users\\WERO\\RiderProjects\\WebApplication9\\WebApplication9\\View\\Home\\GameStartFile.html");

        return Content(htmlContent, "text/html");
    }
  

   
    
    
    
}