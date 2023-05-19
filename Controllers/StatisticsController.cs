using Microsoft.AspNetCore.Mvc;
using RestApi_test.Db;
using System.ComponentModel.DataAnnotations;

namespace RestApi_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public StatisticsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<StatisticsResult> GetStatistics()
        {
            var statistics = _dbContext.Experiments
                .GroupBy(x => x.ExperimentType)
                .Select(g => new ExperimentStatistics
                {
                    ExperimentType = g.Key,
                    TotalDevices = g.Sum(x => x.TotalDevices),
                    Options = g.SelectMany(x => x.Options)
                        .GroupBy(x => x.OptionValue)
                        .Select(g2 => new ExperimentOption
                        {
                            OptionValue = g2.Key,
                            DevicesCount = g2.Sum(x => x.DevicesCount)
                        })
                        .ToList()
                })
                .ToList();

            var result = new StatisticsResult
            {
                Experiments = statistics
            };

            return result;

        }
    }

    public class ExperimentStatistics
    {
        public string ExperimentType { get; set; }
        public int TotalDevices { get; set; }
        public List<ExperimentOption> Options { get; set; }
    }

    public class ExperimentOption
    {
        [Key]
        public int Id { get; set; }
        public string OptionValue { get; set; }
        public int DevicesCount { get; set; }
    }

    public class StatisticsResult
    {
        public List<ExperimentStatistics> Experiments { get; set; }
    }
}
