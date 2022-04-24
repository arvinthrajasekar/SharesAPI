using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class HomeController : ControllerBase
    {
        private readonly ISharesRepository _sharesRepository;
        private readonly ShareDbContext _shareDbContext;
        //private readonly IMapper _mapper;

        public HomeController(ISharesRepository sharesRepository, ShareDbContext shareDbContext)
        {
            _sharesRepository = sharesRepository;
            _shareDbContext = shareDbContext;

        }

        /*public object Get()
        {
            return new { Name = "HDD", Price = "2233" };
        }*/



        [HttpGet("{name}")]
        //[Route("ShareByName")]
        public IActionResult GetPrice(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    string CompNameRegex = @"^(?=.*[a - zA - Z0 - 9]).+$";
                    Regex re = new Regex(CompNameRegex);
                    if (!re.IsMatch(name))
                    {
                        ModelState.AddModelError("Name", "Company Name is not valid.");
                        return BadRequest("Company Name is not valid.");
                    }

                }
                else 
                {
                    ModelState.AddModelError("Name", "Name is required!!!");
                    return BadRequest("Name is required!!!");

                }
                if (ModelState.IsValid)
                {
                    /*List<Shares> AllShares = new List<Shares>();
                    AllShares.Add(new Shares { Name = "3M India Ltd", Price = 21145 });
                    AllShares.Add(new Shares { Name = "Aarti Drugs Ltd", Price = 519 });
                    AllShares.Add(new Shares { Name = "Tata Power", Price = 277.8 });
                    AllShares.Add(new Shares { Name = "HDFC Bank", Price = 1516.75 });
                    AllShares.Add(new Shares { Name = "Zee Entertainment", Price = 284.75 });*/

                    //var result = from r in _sharesRepository.AllShares 
                    var result = from r in _shareDbContext.Share
                                 where r.Name == name
                                 select new { Name = r.Name, Price = r.Price };
                    //result = AllShares.FirstOrDefault(m=> m.Name == name);
                    if (result.Count() == 0)
                    {
                        return NotFound("Company Does not exist.");

                    }
                    return new ObjectResult(result);
                }
                else
                {

                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        


        [HttpGet]
        //[Route("AllUsers")]
        public  IEnumerable<Shares> GetALL()
        {
            /*List<Shares> AllShares = new List<Shares>();
            AllShares.Add(new Shares { Name = "3M India Ltd", Price = 21145 });
            AllShares.Add(new Shares { Name = "Aarti Drugs Ltd", Price = 519 });
            AllShares.Add(new Shares { Name = "Tata Power", Price = 277.8 });
            AllShares.Add(new Shares { Name = "HDFC Bank", Price = 1516.75 });
            AllShares.Add(new Shares { Name = "Zee Entertainment", Price = 284.75 });*/

            //var result = _sharesRepository.AllShares;
            var result = _shareDbContext.Share;
            return result;
        }
        [HttpPost]
        //[Route("NewShare")]
        public IActionResult Post(Shares shares)
        {
            try
            {
                _shareDbContext.Share.Add(shares);
                _shareDbContext.SaveChanges();
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }


    }


    /*public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }*/
}
