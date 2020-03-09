using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Permackathon.Models;
using System.Diagnostics;

namespace Permackathon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, ILogger<HomeController> logger)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //Sample of automapper usage
            //ActivityTO activityTO = _mapper.Map<ActivityTO>(activity);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
