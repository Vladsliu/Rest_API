using Microsoft.AspNetCore.Mvc;
using RestApi_test.Db;
using RestApi_test.Models;

namespace RestApi_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperimentController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ExperimentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("button-color")]
        public ActionResult<ExperimentResult> GetButtonColorExperiment(string deviceToken)
        {
            var experimentResult = _dbContext.ExperimentResults.FirstOrDefault(r => r.Key == "button_color" && r.DeviceToken == deviceToken);

            if (experimentResult != null)
            {
                return experimentResult;
            }

            var experimentValue = GetButtonColorValue();
            experimentResult = new ExperimentResult
            {
                Key = "button_color",
                Value = experimentValue,
                DeviceToken = deviceToken
            };

            _dbContext.ExperimentResults.Add(experimentResult);
            _dbContext.SaveChanges();

            return experimentResult;
        }

        [HttpGet("price")]
        public ActionResult<ExperimentResult> GetPriceExperiment(string deviceToken)
        {
            var experimentResult = _dbContext.ExperimentResults.FirstOrDefault(r => r.Key == "price" && r.DeviceToken == deviceToken);

            if (experimentResult != null)
            {
                return experimentResult;
            }

            var experimentValue = GetPriceValue();
            experimentResult = new ExperimentResult
            {
                Key = "price",
                Value = experimentValue,
                DeviceToken = deviceToken
            };

            _dbContext.ExperimentResults.Add(experimentResult);
            _dbContext.SaveChanges();

            return experimentResult;
        }

        private string GetButtonColorValue()
        {
            var colors = new[] { "#FF0000", "#00FF00", "#0000FF" };
            var random = new Random();
            var index = random.Next(colors.Length);
            return colors[index];
        }

        private string GetPriceValue()
        {
            var random = new Random();
            var randomNumber = random.Next(100);

            if (randomNumber < 75)
            {
                return "10";
            }
            else if (randomNumber < 85)
            {
                return "20";
            }
            else if (randomNumber < 90)
            {
                return "50";
            }
            else
            {
                return "5";
            }
        }
    }
}
