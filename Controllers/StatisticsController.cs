using Microsoft.AspNetCore.Mvc;
using Rest_API_final.Interfaces;
using Rest_API_final.Models;
using Rest_API_final.Data.DTO;
using System.Drawing;

namespace Rest_API_final.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController: Controller
    {

        private readonly IExperimentRepository _experimentRepository;
        public StatisticsController(IExperimentRepository experimentRepository)
        {
            _experimentRepository = experimentRepository;
        }

        [HttpGet("color")]
        [ProducesResponseType(200, Type = typeof(Statistics))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetStatisticsColor()
        {
            StatisticsDTO statisticsDTO = new StatisticsDTO
            {
                ExperimentName = "button_color",
                TotalDevices = _experimentRepository.GetValueOfExperiment("button_color"),
                OptionDistribution = new Dictionary<string, int>()
                {
                    {"#FF0000", _experimentRepository.GetCountOfExperimentByOptinValue("#FF0000") },
                    {"#00FF00", _experimentRepository.GetCountOfExperimentByOptinValue("#00FF00") },
                    {"#0000FF", _experimentRepository.GetCountOfExperimentByOptinValue("#0000FF") },
                } 
            };

            return Ok(statisticsDTO);
        }

        [HttpGet("price")]
        [ProducesResponseType(200, Type = typeof(Statistics))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetStatisticsPrice()
        {

            StatisticsDTO statisticsDTO = new StatisticsDTO
            {
                ExperimentName = "price",
                TotalDevices = _experimentRepository.GetValueOfExperiment("price"),
                OptionDistribution = new Dictionary<string, int>()
                {
                    {"10", _experimentRepository.GetCountOfExperimentByOptinValue("10") },
                    {"20", _experimentRepository.GetCountOfExperimentByOptinValue("20") },
                    {"50", _experimentRepository.GetCountOfExperimentByOptinValue("50") },
                    {"5", _experimentRepository.GetCountOfExperimentByOptinValue("5") },
                }
            };

            return Ok(statisticsDTO);
        }
    }
}
