using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permackathon.BL.UseCases.Charts;
using Permackathon.DAL.UnitOfWork;
using Permackathon.Models;
using System.Diagnostics;

namespace Permackathon.Controllers
{
    public class ChartController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private FusionChart fusionChart;
        private PieChart pieChart;

        public ChartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            fusionChart = new FusionChart(_unitOfWork);
            pieChart = new PieChart(_unitOfWork);
        }

        public IActionResult Pie()
        {
            var sum = pieChart.InitilizePie(2019);
            return View();
        }

        public IActionResult Fusion()
        {
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