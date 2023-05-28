using Rest_API_final.Models;

namespace Rest_API_final.Interfaces
{
    public interface IExperimentResultRepository
    {
        ExperimentResult GetExperimentResultByDeviceToken(string deviceToken);
    }
}
