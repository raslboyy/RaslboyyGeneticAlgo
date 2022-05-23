namespace GeneticAlgo.Shared.Models;

public class ExecutionConfiguration
{
    public int IterationDelayMilliseconds { get; set; }
    public  int MaximumValue { get; set; }
    public int MinimumValue { get; set; }
    public ExecutionConfiguration()
    {
        IterationDelayMilliseconds = Core.SharedModels.Configuration.GetInstance().Dt;
        MinimumValue = 0;
        MaximumValue = 1;
    }
}