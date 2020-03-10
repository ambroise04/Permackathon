using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Permackathon.BL.UseCases.Charts;
using Permackathon.DAL.UnitOfWork;
using Permackathon.Models;
using System.Diagnostics;

namespace Permackathon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private FusionChart fusionChart;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HomeController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            fusionChart = new FusionChart(_unitOfWork);
        }

        public IActionResult Index()
        {
            //Sample of automapper usage
            //ActivityTO activityTO = _mapper.Map<ActivityTO>(activity);
            var result = fusionChart.Fusion(1, 2019);
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
