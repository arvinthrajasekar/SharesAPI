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

        //private readonly ShareDbContext _shareDbContext;
        /*public HomeController(ISharesRepository sharesRepository, ShareDbContext shareDbContext)
        {
            _sharesRepository = sharesRepository;
            _shareDbContext = shareDbContext;

        }*/

        public HomeController(ISharesRepository context)
        {
            _sharesRepository = context;
        }

        /*public object Get()
        {
            return new { Name = "HDD", Price = "2233" };
        }*/
        /*public ActionResult Index()
        {
            return View();
        }*/

        [HttpGet("{name}")]
        //[Route("ShareByName")]
        public ActionResult<Shares> GetPrice(string name)
        {
            
                if (!string.IsNullOrEmpty(name))
                {
                    string CompNameRegex = @"^(?=.*[a - zA - Z0 - 9]).+$";
                    Regex re = new Regex(CompNameRegex);
                    if (!re.IsMatch(name))
                    {
                        //ModelState.AddModelError("Name", "Company Name is not valid.");
                        return BadRequest("Company Name is not valid.");
                    }
                }
                else 
                {
                    //ModelState.AddModelError("Name", "Name is required!!!");
                    return BadRequest("Name is required!!!");
                }
                if (ModelState.IsValid)
                {
                    //List<Shares> AllShares = new List<Shares>();
                    //AllShares.Add(new Shares { Name = "3M India Ltd", Price = 21145 });
                    //AllShares.Add(new Shares { Name = "Aarti Drugs Ltd", Price = 519 });
                    //AllShares.Add(new Shares { Name = "Tata Power", Price = 277.8 });
                    //AllShares.Add(new Shares { Name = "HDFC Bank", Price = 1516.75 });
                    //AllShares.Add(new Shares { Name = "Zee Entertainment", Price = 284.75 });

                    var result = _sharesRepository.GetShares(name);
                    if (result == null)
                    {
                        return NotFound("Company Does not exist.");
                    }
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            
            
        }

        [HttpGet]
        //[Route("AllUsers")]
        public  ActionResult<IEnumerable<Shares>> GetALL()
        {   
            var result = _sharesRepository.AllShares();
            return Ok(result);
        }

        [HttpPost]
        //[Route("NewShare")]
        public IActionResult Post(Shares shares)
        {
            
                //_shareDbContext.Share.Add(shares);
                //_shareDbContext.SaveChanges();
                if(string.IsNullOrEmpty(shares.Name))
                {
                    return BadRequest("Name Is Required!!!");
                }
                
                _sharesRepository.CreateAsync(shares);
                return Ok();
            
        }
    }
}
