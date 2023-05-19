using Microsoft.EntityFrameworkCore;
using RestApi_test.Controllers;
using RestApi_test.Data;
using RestApi_test.Db;
using RestApi_test.Models;

public class StatisticsService
{
    private readonly AppDbContext _dbContext;

    public StatisticsService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ExperimentData>> GetExperimentStatisticsAsync()
    {
        List<ExperimentResult> experimentResults = await _dbContext.ExperimentResults.ToListAsync();

        List<ExperimentData> experiments = new List<ExperimentData>();

        var groupedExperiments = experimentResults.GroupBy(result => result.Key);

        foreach (var group in groupedExperiments)
        {
            string experimentType = group.Key;
            int totalDevices = group.Count();

            var groupedOptions = group.GroupBy(result => result.Value)
                .Select(optionGroup => new ExperimentOption { OptionValue = optionGroup.Key, DevicesCount = optionGroup.Count() })
                .ToList();

            ExperimentData experimentData = new ExperimentData
            {
                ExperimentType = experimentType,
                TotalDevices = totalDevices,
                Options = groupedOptions
            };
            experiments.Add(experimentData);
        }
        return experiments;
    }
}
