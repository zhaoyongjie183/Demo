using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Middleware.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        //private static IServiceProvider _ServiceProvider;

        // private readonly ILogger _ILogger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            ///var  log= _ServiceProvider.GetService<typeof(ILoggerFactory)>().ContentRootPath;

            // _ILogger = LogManager.GetLogger(repository.Name, "NETCorelog4net");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            //Log4NetLoggingFactory loggingFactory = new Log4NetLoggingFactory();

             //_logger.LogError("sadasd");
             // var c=Summaries[100];
             var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
