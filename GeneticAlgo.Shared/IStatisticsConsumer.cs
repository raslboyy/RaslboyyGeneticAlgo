using GeneticAlgo.Core.SharedModels;

namespace GeneticAlgo.Shared;

public interface IStatisticsConsumer
{
    void Consume(IterationStatistic statistic, IReadOnlyCollection<BarrierCircle> barriers);
}