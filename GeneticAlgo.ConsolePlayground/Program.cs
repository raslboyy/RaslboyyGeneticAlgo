using Serilog;

using GeneticAlgo.Core.Models.GeneticAlgorithmBuilderModels;
using GeneticAlgo.Shared;

Logger.Init();

var algorithm = new GeneticAlgorithm();
int iterationCount = 1;
var result = algorithm.Iteration();
while (result.Result == GeneticAlgo.Core.SharedModels.IterationResult.IterationFinished)
{
    result = algorithm.Iteration();
    iterationCount++;
}

Log.Information($"{result.Result} {iterationCount}");
Console.WriteLine($"{result.Result} {iterationCount}");