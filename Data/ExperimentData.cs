using RestApi_test.Controllers;

namespace RestApi_test.Data
{
    public class ExperimentData
    {
        public string ExperimentType { get; set; }
        public int TotalDevices { get; set; }
        public List<ExperimentOption> Options { get; set; }
    }
    public class Option
    {
        public string OptionValue { get; set; }
        public int DevicesCount { get; set; }
    }
}
