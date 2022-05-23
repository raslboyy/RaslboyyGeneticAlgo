namespace GeneticAlgo.Core.SharedModels;

public record struct Point(double X, double Y)
{ 
    public static double GetDistance(Point p1, Point p2) => Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
}