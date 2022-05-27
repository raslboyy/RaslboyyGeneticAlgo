namespace GeneticAlgo.Core.SharedModels;
public struct IterationStatistic
{
    public IterationResult Result = IterationResult.IterationFinished;
    public List<Statistic> Statictics = new();
    public List<IndividualStatistic> IndividualStatistics = new();

    public IterationStatistic() {}
}