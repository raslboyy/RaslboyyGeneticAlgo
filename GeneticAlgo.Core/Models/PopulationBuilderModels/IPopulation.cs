using GeneticAlgo.Core.SharedModels;

namespace GeneticAlgo.Core.Models.PopulationBuilderModels;

public interface IPopulation
{
    void Kill(IFitnessFunction fitnessFunction, double killRate);
    void Mutate(IMutationAlgorithm mutationAlgorithm, double killRate, double mutationAddGenCoefficient);
    void Crossing(INextGenerationAlgorithm algorithm, double crossingRate, double killRate);
    void RandomSurvive(double randomSurviveRate);
    IterationStatistic Evaluation(IFitnessFunction fitnessFunction);
}