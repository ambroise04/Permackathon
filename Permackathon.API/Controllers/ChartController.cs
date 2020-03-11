using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Permackathon.BL.UseCases.Charts;
using Permackathon.DAL.UnitOfWork;
using System;

namespace Permackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private PieChart pieChart;
        private FusionChart fusionChart;

        public ChartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            pieChart = new PieChart(_unitOfWork);
            fusionChart = new FusionChart(_unitOfWork);
        }

        [HttpGet("pie/{year}")]
        public IActionResult GetPie(int? year)
        {
            if (!year.HasValue)
            {
                year = DateTime.Now.Year;
            }
            var sum = pieChart.InitilizePie(year.Value);

            return Ok(sum);
        }

        [HttpGet("fusion/{year}")]
        public IActionResult GetFusion(int? year)
        {
            if (!year.HasValue)
            {
                year = DateTime.Now.Year;
            }
            var result = fusionChart.Fusion(year.Value);

            return Ok(result);
        }
    }
}