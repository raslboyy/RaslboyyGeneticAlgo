namespace GeneticAlgo.Core.SharedModels;
public class IterationStatistic
{
    public IterationResult Result;
    public List<Statistic> Statictics = new();
    public List<IndividualStatistic> IndividualStatistics = new();
}