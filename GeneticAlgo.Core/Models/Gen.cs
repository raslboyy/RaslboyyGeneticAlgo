using GeneticAlgo.Core.SharedModels;

namespace GeneticAlgo.Core.Models
{
    public struct Gen
    {
        private readonly MyRandom _random = MyRandom.GetInstance();
        public Vector R { get; private set; }
        public double X { get { return R.X; } }
        public Gen(double x, double y)
        {
            R = new Vector(x, y);
            if (R.Len() > Configuration.GetInstance().FMax)
                R.Normalize(R.Len() / Configuration.GetInstance().FMax);
        }
        public Gen()
        {
            R = new Vector((_random.NextDouble() * 2 - 1) / 20, (_random.NextDouble() * 2 - 1) / 20);
            if (R.Len() > Configuration.GetInstance().FMax)
                R.Normalize(R.Len() / Configuration.GetInstance().FMax);
        }

        public Gen Mutate() { 
            R = R.RandomRotate();
            R = R.RandomLen();
            return this;
        }

        public Gen Copy()
        {
            var g = new Gen
            {
                R = R.Copy()
            };
            return g;
        }
    }
}