using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TigerPhoneAPI.Contexts;
using TigerPhoneAPI.Models;

namespace TigerPhoneAPI.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly TelecomContext _context;

        public DeviceController(TelecomContext context)
        {
            _context = context;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet(Name = "GetAllDevices")]
        public async Task<ActionResult<IEnumerable<Device>>> GetAll()
        {
            if (_context.Devices == null) { return new NotFoundResult(); }
            return await _context.Devices.ToListAsync();
        }
    }
}