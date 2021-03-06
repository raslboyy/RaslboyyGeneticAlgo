namespace GeneticAlgo.Core.Models
{
    public struct Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public void Normalize(double n)
        {
            X /= n;
            Y /= n;
        }
        public double Len() => Math.Sqrt(X * X + Y * Y);
        public Vector RandomRotate()
        {
            // 16
            double alpha = MyRandom.GetInstance().NextDouble() * Math.PI / 16.0 * (MyRandom.GetInstance().Next() % 2 == 0 ? 1 : -1);
            double x = Math.Cos(alpha) * X - Math.Sin(alpha) * Y;
            double y = Math.Sin(alpha) * X + Math.Cos(alpha) * Y;
            return new Vector(x, y);
        }

        public Vector RandomLen()
        {
            // 3.5 / 4.0
            double k = (MyRandom.GetInstance().NextDouble() + 2.5) / 3.0;
            return new Vector(k * X, k * Y);
        }

        public Vector Copy()
        {
            return new Vector(X, Y);
        }
    }
}
