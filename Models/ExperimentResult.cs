using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rest_API_final.Models
{
    public class ExperimentResult
    {
        [Key]
        public int Id { get; set; }
        public int ExperimentId { get; set; }
        public Experiment Experiment { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
    }
}
