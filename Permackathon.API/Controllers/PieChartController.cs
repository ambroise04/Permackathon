using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permackathon.DAL.UnitOfWork;
using Permackathon.BL.UseCases.Charts;
using AutoMapper;

namespace Permackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PieChartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private PieChart pieChart;

        public PieChartController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            pieChart = new PieChart(_unitOfWork);
        }

        [HttpGet]
        public ActionResult<double[]> Get()
        {            
            var sum = pieChart.InitilizePie(2019);
            return Ok(sum);
        }
    }
}