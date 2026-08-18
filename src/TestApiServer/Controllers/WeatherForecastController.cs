using KamiSama.Chassis.HttpExceptions;
using Microsoft.AspNetCore.Mvc;

namespace ChassisTestProject.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        throw new ForbiddenException("KKK");
    }
}
