namespace GeneticAlgo.Core.Models.GeneticAlgorithmBuilderModels
{
    public class GeneticAlgorithm : GeneticAlgorithmAbstract
    {
        public double KillRate { get; set; } = 0.6;
        public double CrossingRate { get; set; } = 0.4;
        public double MutationAddGenCoefficient { get; set; } = 0.3;
        public double RandomSurviveRate { get; set; } = 0.2;
        public GeneticAlgorithm() 
        {
            for (int i = 0; i < 0; i++)
            {
                CurrentPopulation.Kill(FitnessFunction, 0.5);
                CurrentPopulation.Mutate(MutationAlgorithm, 0.5, 0.1);
            }
            
        }

        public override void Killing()
        {
            CurrentPopulation.Kill(FitnessFunction, KillRate);
        }

        public override void Upgrading() { }

        public override void Crossing() {
            CurrentPopulation.Crossing(NextGenerationAlgorithm, CrossingRate, KillRate);
        }

        public override void Mutation()
        {
            CurrentPopulation.Mutate(MutationAlgorithm, KillRate, MutationAddGenCoefficient);
        }

        public override void RandomSurvive()
        {

        }
    }
}
