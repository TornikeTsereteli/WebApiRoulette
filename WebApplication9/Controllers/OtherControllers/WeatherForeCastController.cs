using Microsoft.AspNetCore.Mvc;

namespace WebApplication9.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForeCastController:ControllerBase
{

    private readonly string[] _summaries = 
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
     
    [HttpGet("",Name = "GetWeatherForeCast")]
    public WeatherForecast[] GetFiveWeatherForecast()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20,35),
            _summaries[Random.Shared.Next(0,_summaries.Length)]
        )).ToArray();
    }  
    
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
