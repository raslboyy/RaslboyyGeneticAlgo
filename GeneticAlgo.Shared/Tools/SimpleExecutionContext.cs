using GeneticAlgo.Core.SharedModels;
using GeneticAlgo.Core.Models.GeneticAlgorithmBuilderModels;

namespace GeneticAlgo.Shared.Tools;
public class SimpleExecutionContext : IExecutionContext
{
    private GeneticAlgorithmAbstract _algorithm;
    private IterationStatistic _lastIterationStatistic;
    public SimpleExecutionContext(GeneticAlgorithmBuilder builder)
    {
        _algorithm = builder.GetResult();
    }
    public SimpleExecutionContext() : this(new GeneticAlgorithmBuilder()) { }
    public Task<IterationResult> ExecuteIterationAsync()
    {
        _lastIterationStatistic = _algorithm.Iteration();
        return Task.FromResult(_lastIterationStatistic.Result);
    }
    public void ReportStatistics(IStatisticsConsumer statisticsConsumer)
    {
        statisticsConsumer.Consume(_lastIterationStatistic, Configuration.GetInstance().Circles);
    }
    public void Reset(GeneticAlgorithmBuilder builder)
    {
        _algorithm = builder.GetResult();
    }
    public void Reset()
    {
        Reset(new GeneticAlgorithmBuilder());
    }
}