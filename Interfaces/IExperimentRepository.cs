using RestApi_test.Data;

namespace RestApi_test.Interfaces
{
    public interface IExperimentRepository
    {
        List<ExperimentData> GetExperimentData();
    }
}
