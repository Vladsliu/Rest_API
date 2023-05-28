using Microsoft.AspNetCore.Mvc;
using Rest_API_final.Data.DTO;
using Rest_API_final.Interfaces;
using Rest_API_final.Models;

namespace Rest_API_final.Controllers
{
    [Route("api/[controller]")]
    public class ExperimentController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IExperimentRepository _experimentRepository;
        public ExperimentController(IClientRepository clientRepository, IExperimentRepository experimentRepository)
        {
            _clientRepository = clientRepository;
            _experimentRepository = experimentRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Experiment))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetExperimentColor(Client client)
        {
          
            if (_clientRepository.ClientExist(client.DeviceToken))
            {
                var existExperiment = _experimentRepository.GetExperiment(client.DeviceToken);

                ExperimentDTO existDto = new ExperimentDTO
                {
                    Key = existExperiment.Key,
                    Value = existExperiment.OptionValue
                };

                return Ok(existDto);
            }
            
            var newClient = _clientRepository.CreateClient(client);
         
            List<string> colors = new List<string> { "#FF0000", "#00FF00", "#0000FF" };

            Random random = new Random();
            int randomIndex = random.Next(colors.Count);

            string randomColor = colors[randomIndex];

            Experiment experiment = new Experiment
            {
                ClientId = newClient,
                Key = "button_color",
                OptionValue = randomColor,
                DateTime = DateTime.Now,
            };
     
            if (!_experimentRepository.CreateExperiment(experiment))
            {
                ModelState.AddModelError("", "Something went wrong with experiment");
                return StatusCode(500, ModelState);
            }
            ExperimentDTO experimDto = new ExperimentDTO 
            { 
                Key = experiment.Key,
                Value = experiment.OptionValue
            };

            return Ok(experimDto);
        }
    }
}
