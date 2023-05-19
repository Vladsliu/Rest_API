using RestApi_test.Controllers;
using System.ComponentModel.DataAnnotations;

namespace RestApi_test.Models
{
    public class Experiment
    {
        [Key]
        public int Id { get; set; }
        public string DeviceToken { get; set; }
        public string ExperimentType { get; set; }
        public int TotalDevices { get; set; }
        public List<ExperimentOption> Options { get; set; }

    }

}
