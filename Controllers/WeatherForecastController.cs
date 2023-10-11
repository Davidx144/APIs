using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
        ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast

            {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    /* [Route("Get/WeatherForecast")]
    [Route("[action]")] */
    public IEnumerable<WeatherForecast> GetQ()
    {
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post([FromBody] WeatherForecast weatherForecast)
    {
        if (weatherForecast == null)
        {
            return BadRequest();
        }

        ListWeatherForecast.Add(weatherForecast);
        return Ok("GetWeatherForecastPost");
    }

    [HttpDelete ("{id}")]
    public IActionResult Delete(int id)
    {
        ListWeatherForecast.RemoveAt(id);
        return Ok("GetWeatherForecastDelete");
    }

    
}
