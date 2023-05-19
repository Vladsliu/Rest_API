using Microsoft.EntityFrameworkCore;
using RestApi_test.Data;
using RestApi_test.Interfaces;

namespace RestApi_test.Db
{
    public class ExperimentRepository : IExperimentRepository
    {
        private readonly AppDbContext _dbContext;

        public ExperimentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ExperimentData> GetExperimentData()
        {
            var experiments = _dbContext.Experiments
                .Include(e => e.Options)
                .ToList();

            List<ExperimentData> experimentDataList = experiments.Select(e => new ExperimentData
            {
                ExperimentType = e.ExperimentType,
                TotalDevices = e.TotalDevices,
                Options = e.Options
            }).ToList();

            return experimentDataList;
        }

    }
}
