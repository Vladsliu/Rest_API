using Rest_API_final.Models;

namespace Rest_API_final.Interfaces
{
    public interface IExperimentRepository
    {
        ICollection<Experiment> GetExperiments();
        Experiment GetExperiment(string deviceToken);
        bool CreateExperiment(Experiment experiment);
        bool Save();
    }
}
