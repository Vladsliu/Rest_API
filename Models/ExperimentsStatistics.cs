namespace Rest_API_final.Models
{
    public class ExperimentsStatistics
    {
        public string ExperimentName { get; set; }
        public int TotalDevices { get; set; }
        public Dictionary<string, int> OptionDistribution { get; set; }
    }
}
