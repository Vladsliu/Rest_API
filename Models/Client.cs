using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rest_API_final.Models
{
    public class Client
    {
        [Key]
        [BindNever]
        public int Id { get; set; }
        public string DeviceToken { get; set; }
        public ICollection<Experiment> Experiments { get; set; }
    }
}
