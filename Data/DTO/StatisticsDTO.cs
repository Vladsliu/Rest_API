namespace Rest_API_final.Data.DTO
{
    public class StatisticsDTO
    {
        public string ExperimentName { get; set; }
        public int TotalDevices { get; set; }
        public Dictionary<string, int> OptionDistribution { get; set; }
    }
}
