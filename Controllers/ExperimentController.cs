using Microsoft.AspNetCore.Mvc;
using Rest_API_final.Data.DTO;
using Rest_API_final.Interfaces;
using Rest_API_final.Models;
using System;

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

        [HttpGet("color")]
        [ProducesResponseType(200, Type = typeof(Experiment))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetExperimentColor(Client client)
        {
            var experimentKey = "button_color";

            if (_clientRepository.ClientExist(client.DeviceToken) && _clientRepository.GetKeyByClient(client) == experimentKey)
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
                Key = experimentKey,
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

        [HttpGet("price")]
        [ProducesResponseType(200, Type = typeof(Experiment))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult GetExperimentPrice(Client client)
        {
            var experimentKey = "price";

            if (_clientRepository.ClientExist(client.DeviceToken)&&_clientRepository.GetKeyByClient(client) == experimentKey)
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

            var random = new Random();
            int randomNumber = random.Next(1, 101);
            string price;

            if (randomNumber <= 75)
                price = "10"; 
            else if (randomNumber <= 85)
                price = "20";
            else if (randomNumber <= 90)
                price = "50"; 
            else
                price = "5"; 

            Experiment experiment = new Experiment
            {
                ClientId = newClient,
                Key = experimentKey,
                OptionValue = price,
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
