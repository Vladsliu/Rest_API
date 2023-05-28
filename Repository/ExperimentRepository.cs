﻿using Rest_API_final.Data;
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

        //public Experiment GetExperimentByDeviceToken(string deviceToken)
        //{//написать чтоб возвращался експеримент по девайс токену
        //    return _context.Experiments.Where(e => e.)
        //}

        public ICollection<Experiment> GetExperiments()
        {
            return _context.Experiments.ToList();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }
    }
}
