using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rest_API_final.Models
{
    public class Experiment
    {
        [Key]
        public int Id { get; set; }
        public string OptionValue { get; set; }
        public string Key { get; set; }
        public DateTime DateTime { get; set; }
        public int ClientId { get; set; } 
        public Client Client { get; set; }

    }
}
