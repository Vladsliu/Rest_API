using System.ComponentModel.DataAnnotations;

namespace Rest_API_final.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string DeviceToken { get; set; }
        public ICollection<ExperimentResult> ExperimentResults { get; set; }
    }
}
