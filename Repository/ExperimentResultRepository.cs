using Microsoft.EntityFrameworkCore;
using Rest_API_final.Data;
using Rest_API_final.Interfaces;
using Rest_API_final.Models;

namespace Rest_API_final.Repository
{
    public class ExperimentResultRepository : IExperimentResultRepository
    {
        private readonly DataContext _context;
        public ExperimentResultRepository(DataContext context)
        {
            _context= context;
        }
        public ExperimentResult GetExperimentResultByDeviceToken(string deviceToken)
        {
            return _context.ExperimentResults.Where(e => e.Client.DeviceToken == deviceToken).FirstOrDefault();
        }
    }
}


