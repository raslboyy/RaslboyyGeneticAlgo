using GeneticAlgo.Core.SharedModels;

namespace GeneticAlgo.Shared
{
    public interface IExecutionContext
    {
        void Reset();
        Task<IterationResult> ExecuteIterationAsync();
        void ReportStatistics(IStatisticsConsumer statisticsConsumer);
    }
}