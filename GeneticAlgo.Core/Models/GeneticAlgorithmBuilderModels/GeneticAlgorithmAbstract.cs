using GeneticAlgo.Core.Models.PopulationBuilderModels;
using GeneticAlgo.Core.SharedModels;
using Serilog;

namespace GeneticAlgo.Core.Models.GeneticAlgorithmBuilderModels
{
    public abstract class GeneticAlgorithmAbstract
    {
        public IPopulation CurrentPopulation { get; set; } = new Population();
        public PopulationBuilder PopulationBuilder { get; set; } = new();
        public IFitnessFunction FitnessFunction { get; set; } = new SimpleFitnessFunction();
        public IMutationAlgorithm MutationAlgorithm { get; set; } = new SimpleMutationAlgorithm();
        public INextGenerationAlgorithm NextGenerationAlgorithm { get; set; } = new SimpleNextGenerationAlgorithm();
        public int MaxCountIteration { get; set; } = 1000;
        public int CountIteration { get; set; } = 0;
        public GeneticAlgorithmAbstract()
        {
            Logger.Init();
        }

        public IterationStatistic Iteration()
        {
            var statistic = Selection();

            //Log.Debug(((Population)CurrentPopulation).ToString());

            Crossing();

            Mutation();

            //Log.Debug(((Population)CurrentPopulation).ToString());

            CountIteration++;

            if (CountIteration >= MaxCountIteration)
            {
                statistic.Result = IterationResult.SolutionCannotBeFound;
            }

            return statistic;
        }

        public IterationStatistic Selection()
        {
            var statistic = Evaluation();

            Killing();

            RandomSurvive();

            Upgrading();

            return statistic;
        }

        public abstract void Crossing();
        public abstract void Mutation();

        public IterationStatistic Evaluation() {
            return CurrentPopulation.Evaluation(FitnessFunction);
        }

        public abstract void Killing();

        public abstract void Upgrading();

        public abstract void RandomSurvive();
    }
}
