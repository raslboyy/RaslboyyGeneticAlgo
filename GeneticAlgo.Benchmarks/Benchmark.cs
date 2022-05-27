

using BenchmarkDotNet.Attributes;
using GeneticAlgo.Core.Models.GeneticAlgorithmBuilderModels;
using GeneticAlgo.Core.Models.PopulationBuilderModels;

namespace GeneticAlgo.Benchmarks;

[MemoryDiagnoser]
[IterationCount(10)]
[WarmupCount(0)]
//[ShortRunJob]
public class Benchmark
{
    [Params(100, 500, 1000)]
    public int PopulationSize { get; set; }
    [Params(0.6, 0.7, 0.8)]
    public double KillRate { get; set; }
    [Params(0.1, 0.2)]
    public double RandomSurviveRate { get; set; }
    public GeneticAlgorithm Algorithm { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var populationBuilder = new LastPopulationBuilder();
        populationBuilder
            .SetSize(PopulationSize);
        var genAlgoBuilder = new LastGeneticAlgorithmBuilder();
        genAlgoBuilder.SetPopulation(populationBuilder);
        Algorithm = genAlgoBuilder.GetResult();
        Algorithm.KillRate = KillRate;
        Algorithm.RandomSurviveRate = RandomSurviveRate;
    }

    [Benchmark(Description = "Solving")]
    public void Solving()
    {
        var result = Algorithm.Iteration();
        while (result.Result == Core.SharedModels.IterationResult.IterationFinished)
        {
            result = Algorithm.Iteration();
        }
    }
}