using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpPost(Name = "GetWeatherForecast")]
    public ActionResult GetLocation(string location)
    {
      return Content(location, "text/plain");
    }

    [HttpGet]
    public void GetUser(string unsafeUserId, string connectionString)
    {
      string query = "SELECT * FROM Users WHERE Id = " + unsafeUserId;

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        SqlCommand reader = command;
      }
    }
  }
}
