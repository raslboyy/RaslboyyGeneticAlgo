using GeneticAlgo.Core.Models;
using GeneticAlgo.Core.SharedModels;
using GeneticAlgo.Shared;
using GeneticAlgo.Shared.Models;
using OxyPlot;
using OxyPlot.Series;

namespace GeneticAlgo.UIShared;

public class PlotStatisticConsumer : IStatisticsConsumer
{
    private readonly PlotModel _series;
    private readonly LinearBarSeries _linearBarSeries;

    public PlotStatisticConsumer(PlotModel series, LinearBarSeries linearBarSeries)
    {
        _linearBarSeries = linearBarSeries;
        _series = series;
    }

    public void Consume(IterationStatistic allStatistic, IReadOnlyCollection<BarrierCircle> barriers)
    {
        _series.Series.Clear();
        _series.Series.Add(new ScatterSeries() {
            MarkerSize = 3,
            MarkerStroke = OxyColors.ForestGreen,
            MarkerType = MarkerType.Plus,
        });

        var statistics = allStatistic.Statictics;
        foreach (var statistic in statistics)
        {
            var point = statistic.Point;
            ((ScatterSeries)_series.Series[0]).Points.Add(new ScatterPoint(point.X, point.Y));
        }

        _series.Series.Add(new ScatterSeries()
        {
            MarkerSize = 1,
            MarkerStroke = OxyColors.Red,
            MarkerType = MarkerType.Circle,
        });
        ((ScatterSeries)_series.Series[1]).Points.Add(new ScatterPoint(1, 1));

        
        var individualStatistics = allStatistic.IndividualStatistics;
        for (int i = 0; i < individualStatistics.Count && allStatistic.Result != IterationResult.SolutionFound; i++)
        {
            var color = OxyColors.CadetBlue;
            _series.Series.Add(new LineSeries()
            {
                Color = color
            });
            ((LineSeries)_series.Series[^1]).Points.Add(new DataPoint(0, 0));
            individualStatistics[i].Points.ForEach(point => ((LineSeries)_series.Series[^1]).Points.Add(new DataPoint(point.X, point.Y)));
        }

        for (int i = 0; i < individualStatistics.Count && allStatistic.Result == IterationResult.SolutionFound; i++)
        {
            if (statistics[i].Fitness < Configuration.GetInstance().Eps)
            {
                _series.Series.Add(new LineSeries()
                {
                    Color = OxyColors.Black
                });
                ((LineSeries)_series.Series[^1]).Points.Add(new DataPoint(0, 0));
                individualStatistics[i].Points.ForEach(point => ((LineSeries)_series.Series[^1]).Points.Add(new DataPoint(point.X, point.Y)));
            }
        }

        const double eps = 0.0001;
        foreach (var (point, radius) in barriers)
        {
            double round1(double x) => Math.Sqrt(Math.Max(radius * radius - (x - point.X) * (x - point.X), 0)) + point.Y;
            double round2(double x) => -Math.Sqrt(Math.Max(radius * radius - (x - point.X) * (x - point.X), 0)) + point.Y;
            _series.Series.Add(new FunctionSeries(round1, point.X - radius, point.X + radius + eps, eps)
            {
                Color = OxyColors.Red,
            });
            _series.Series.Add(new FunctionSeries(round2, point.X - radius, point.X + radius + eps, eps)
            {
                Color = OxyColors.Red,
            });
        }

        _linearBarSeries.ItemsSource = statistics
            .Select(s => new FitnessModel(s.Id, s.Fitness))
            .ToArray();
    }
}