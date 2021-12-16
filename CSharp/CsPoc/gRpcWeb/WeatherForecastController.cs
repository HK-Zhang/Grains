using GrpcGreeter;
using Microsoft.AspNetCore.Mvc;

namespace gRpcWeb
{
    [ApiController]
    [Route("api/weatherForecast")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly Greeter.GreeterClient _client;

        public WeatherForecastController(Greeter.GreeterClient client)
        {
            _client = client;
        }


        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var call = await _client.SayHelloAsync(new HelloRequest { Name = "World" });


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = call.Message
            })
            .ToArray();
        }

    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
