using Rest_API_final.Models;

namespace Rest_API_final.Interfaces
{
    public interface IExperimentRepository
    {
        int GetValueOfExperiment(string key);
        int GetCountOfExperimentByOptinValue(string optionValue);
        Experiment GetExperiment(string deviceToken);
        bool CreateExperiment(Experiment experiment);
        bool Save();
    }
}
