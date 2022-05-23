using GeneticAlgo.Core.SharedModels;

namespace GeneticAlgo.Core.Models
{
    public class Chromosome
    {
        public List<Gen> Gens { get; }
        public int Size { get { return Gens.Count; } }
        public Chromosome(int n)
        {
            Gens = new List<Gen>();
            for (int i = 0; i < n; i++)
                Gens.Add(new Gen(1.0 / n, 1.0 / n));
        }

        public Chromosome(Chromosome other)
        {
            Gens = new List<Gen>(other.Gens);
        }

        public Point GetPosition() => new (GetPositionX(), GetPositionY());

        protected double GetPositionX()
        {
            double x = 0;
            foreach(var gen in Gens)
            {
                x += gen.R.X;
            }
            return x;
        }

        protected double GetPositionY()
        {
            double y = 0;
            foreach (var gen in Gens)
            {
                y += gen.R.Y;
            }
            return y;
        }

        public override string ToString()
        {
            return $"{Math.Round(GetPositionX(), 3)} {Math.Round(GetPositionY(), 3)} {Math.Round((new SimpleFitnessFunction()).Calculate(this), 3)}";
        }
    }
}
