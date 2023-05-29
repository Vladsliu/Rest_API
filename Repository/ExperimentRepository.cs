using Rest_API_final.Data;
using Rest_API_final.Interfaces;
using Rest_API_final.Models;

namespace Rest_API_final.Repository
{
    public class ExperimentRepository : IExperimentRepository
    {
        private DataContext _context;
        public ExperimentRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateExperiment(Experiment experiment)
        {
             _context.Add(experiment);
            return Save();
        }

        public int GetCountOfExperimentByOptinValue(string optionValue)
        {
           return _context.Experiments.Count(e => e.OptionValue == optionValue);
        }

        public Experiment GetExperiment(string deviceToken)
        {
            return _context.Experiments.Where(e => e.Client.DeviceToken == deviceToken).FirstOrDefault();
        }

        public int GetValueOfExperiment(string Key)
        {
            return _context.Experiments.Count(e => e.Key == Key);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }
    }
}
