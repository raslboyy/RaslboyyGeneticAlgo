

using GeneticAlgo.Core.SharedModels;

namespace GeneticAlgo.Core.Models
{
    public class SimpleFitnessFunction : IFitnessFunction
    {
        public double Calculate(Chromosome chromosome)
        {
            double distance = Point.GetDistance(chromosome.GetPosition(), new Point(1, 1));

            //double f = Math.Exp(distance);
            double f = distance * distance;

            var prev = new Point(0, 0);
            foreach (var gen in chromosome.Gens)
            {
                var cur = prev;
                cur.X += gen.R.X;
                cur.Y += gen.R.Y;

                double a = Point.GetDistance(prev, cur);

                foreach (var circle in Configuration.GetInstance().Circles)
                {
                    double b = Point.GetDistance(prev, circle.Center);
                    double c = Point.GetDistance(cur, circle.Center);

                    double distFromCenterToSegment = 0;

                    if (IsTriangle(a, b, c))
                        distFromCenterToSegment = 2 * GetS(a, b, c) / a;
                    f += Math.Max(0, circle.Radius - distFromCenterToSegment);
                }

                prev = cur;
            }

            return f;
        }

        private static double GetS(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        private static bool IsTriangle(double a, double b, double c)
        {
            if (a >= b + c)
                return false;
            if (b >= a + c)
                return false;
            if (c >= a + b)
                return false;
            return true;
        }
    }
}
