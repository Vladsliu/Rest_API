using System.ComponentModel.DataAnnotations;

namespace RestApi_test.Models
{
    public class ExperimentResult
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string DeviceToken { get; set; }
    }
}
