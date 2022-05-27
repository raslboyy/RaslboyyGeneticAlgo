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
        private HashSet<int> _isUsedForRandomSurvive { get; set; } = new ();
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
            var fromPool = ArrayPool<Chromosome>.Shared.Rent(Chromosomes.Count);
            int i = 0;
            foreach (var ind in Chromosomes)
            {
                fromPool[i++] = ind;
            }
            i = 0;
            foreach (var ind in fromPool.OrderBy(ind => ind == null ? 1000000000 : fitnessFunction.Calculate(ind)))
            {
                Chromosomes[i++] = ind;
                if (i == Chromosomes.Count)
                    break;
            }
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
                Chromosomes.Add(new Chromosome(Chromosomes[_random.Next(0, len)], RandomSurvived, _isUsedForRandomSurvive));
                mutationAlgorithm.Mutate(Chromosomes[^1], mutationAddGenCoefficient);
            }
            _isUsedForRandomSurvive.Clear();
        }

        public IterationStatistic Evaluation(IFitnessFunction fitnessFunction)
        {
            var statistic = new IterationStatistic()
            {
                Statictics = new List<Statistic>(Chromosomes.Count)
            };
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
                var shared = ArrayPool<Point?>.Shared;
                var points = shared.Rent(individual.Gens.Count);
                for (int i = 0; i < individual.Gens.Count; i++)
                {
                    points[i] = new Point(x += individual.Gens[i].R.X, y += individual.Gens[i].R.Y);
                }
                statistic.IndividualStatistics.Add(new IndividualStatistic(
                    points
                    ));
                if (Math.Abs(Point.GetDistance(new Point(1, 1), individual.GetPosition())) < Configuration.GetInstance().Eps)
                {
                    statistic.Result = IterationResult.SolutionFound;
                }
                shared.Return(points);
            }
            return statistic;
        }

        public void RandomSurvive(double randomSurviveRate)
        {
            int len = (int)(randomSurviveRate * Size);
            for (int i = 0; i < len; i++)
            {
                Chromosomes.Add(RandomSurvived[MyRandom.GetInstance().Next(RandomSurvived.Count)]);
                _isUsedForRandomSurvive.Add(i);
            }
        }
    }
}
