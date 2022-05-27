using GeneticAlgo.Core.SharedModels;
using System.Buffers;

namespace GeneticAlgo.Core.Models.PopulationBuilderModels
{
    public class Population : IPopulation
    {
        private readonly MyRandom _random = MyRandom.GetInstance();
        public List<Chromosome> Chromosomes { get; private set;  } = new ();
        public int MaxLenOfChromosome { get; set; } = 1000;
        public int Size { get; set; } = 500;
        public List<Chromosome> RandomSurvived { get; private set; } = new ();
        public Population()
        {
            for (int i = 0; i < Size; i++)
            {
                Chromosomes.Add(new Chromosome(10));
            }
        }
        public Population(int size)
        {
            Size = size;
            for (int i = 0; i < Size; i++)
            {
                Chromosomes.Add(new Chromosome(_random.Next(2, MaxLenOfChromosome + 1)));
            }
        }
        public void Kill(IFitnessFunction fitnessFunction, double killRate)
        {
            int size = (int)Math.Floor(Size * (1 - killRate));
            Chromosomes = Chromosomes
                .OrderBy(ind => fitnessFunction.Calculate(ind))
                .ToList();
            RandomSurvived = Chromosomes.GetRange(size, Size - size);
            Chromosomes.RemoveRange(size, Size - size);
        }

        public override string ToString()
        {
            string population = $"{Chromosomes.Count}: ";
            foreach(var chromosome in Chromosomes)
            {
                population += $"[{chromosome}] ";
            }
            return population;
        }

        public void Crossing(INextGenerationAlgorithm algorithm, double crossingRate, double killRate)
        {
            int len = (int)Math.Floor(Size * (1 - killRate));
            while (Chromosomes.Count < Size * crossingRate)
            {
                Chromosomes.Add(algorithm.NextGeneration(Chromosomes[_random.Next(0, len)], Chromosomes[_random.Next(0, len)]));
            }
        }

        public void Mutate(IMutationAlgorithm mutationAlgorithm, double killRate, double mutationAddGenCoefficient)
        {
            int len = (int)Math.Floor(Size * (1 - killRate));
            while (Chromosomes.Count < Size)
            {
                Chromosomes.Add(new Chromosome(Chromosomes[_random.Next(0, len)]));
                mutationAlgorithm.Mutate(Chromosomes[^1], mutationAddGenCoefficient);
            }
        }

        public IterationStatistic Evaluation(IFitnessFunction fitnessFunction)
        {
            var statistic = new IterationStatistic();
            int id = 0;
            statistic.Result = IterationResult.IterationFinished;
            foreach (var individual in Chromosomes)
            {
                statistic.Statictics.Add(new Statistic(
                    id++,
                    individual.GetPosition(),
                    fitnessFunction.Calculate(individual))
                    );
                double x = 0;
                double y = 0;
                statistic.IndividualStatistics.Add(new IndividualStatistic(
                    individual.Gens.ToList().ConvertAll(chromosome => new Point(x += chromosome.R.X, y += chromosome.R.Y))
                    ));
                if (Math.Abs(statistic.Statictics.Last().Fitness) < Configuration.GetInstance().Eps)
                {
                    statistic.Result = IterationResult.SolutionFound;
                }
            }
            return statistic;
        }

        public void RandomSurvive(double randomSurviveRate)
        {
            int len = (int)(randomSurviveRate * Size);
            for (int i = 0; i < len; i++)
            {
                Chromosomes.Add(RandomSurvived[MyRandom.GetInstance().Next(RandomSurvived.Count)]);
            }
        }
    }
}
