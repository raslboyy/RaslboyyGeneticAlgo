using GeneticAlgo.Core.Models;

namespace GeneticAlgo.Core
{
    public interface INextGenerationAlgorithm
    {
        Chromosome NextGeneration(Chromosome c1, Chromosome c2);
    }
}