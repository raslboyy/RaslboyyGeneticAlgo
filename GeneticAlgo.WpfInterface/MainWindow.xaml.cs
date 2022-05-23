using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using GeneticAlgo.Core.SharedModels;
using GeneticAlgo.Shared;
using GeneticAlgo.Shared.Models;
using GeneticAlgo.Shared.Tools;
using GeneticAlgo.UIShared;
using OxyPlot;
using OxyPlot.Series;
using Serilog;

namespace GeneticAlgo.WpfInterface
{
    // ReSharper disable once RedundantExtendsListEntry
    public partial class MainWindow : Window
    {
        //TODO: move to configuration
        private readonly static TimeSpan IterationInterval = TimeSpan.FromMilliseconds(1000);

        private bool _isRun = false;
        private bool _isStepByStep = false;
        private double _speed = 1;

        private IStatisticsConsumer _statisticsConsumer;
        private readonly IExecutionContext _executionContext;
        private ExecutionConfiguration _configuration;

        public PlotModel ScatterModel { get; private set; }
        public PlotModel BarModel { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            Logger.Init();

            _executionContext = new SimpleExecutionContext();
            _configuration = new ExecutionConfiguration();

            InitPlots();

            PlotSample.Model = ScatterModel;
            PlotSample2.Model = BarModel;


            var worker = new BackgroundWorker();
            worker.DoWork += StartSimulation;
            worker.RunWorkerAsync();
        }

        public void InitPlots()
        {
            var lineSeries = new ScatterSeries
            {
                MarkerSize = 3,
                MarkerStroke = OxyColors.ForestGreen,
                MarkerType = MarkerType.Plus,
            };

            var circleSeries = new FunctionSeries
            {
                MarkerFill = OxyColors.Red,
            };

            ScatterModel = new PlotModel
            {
                Title = "Points",
                Series = { circleSeries, lineSeries },
            };

            var barSeries = new LinearBarSeries
            {
                DataFieldX = nameof(FitnessModel.X),
                DataFieldY = nameof(FitnessModel.Y),
            };

            BarModel = new PlotModel
            {
                Title = "Fitness",
                Series = { barSeries },
            };

            _statisticsConsumer = new PlotStatisticConsumer(ScatterModel, barSeries);
        }

        private void StartSimulation(object? sender, DoWorkEventArgs e)
        {
            _isRun = false;
            while (true)
            {
                StartSimulator();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        public async void StartSimulator()
        {
            //Log.Information("Start simulation");

            IterationResult iterationResult = IterationResult.IterationFinished;

            while (iterationResult == IterationResult.IterationFinished && _isRun)
            {
                iterationResult = await _executionContext.ExecuteIterationAsync();
                _executionContext.ReportStatistics(_statisticsConsumer);

                ScatterModel.InvalidatePlot(true);
                BarModel.InvalidatePlot(true);

                if (_isStepByStep == true)
                {
                    _isRun = false;
                }
                else
                {
                    Task.Delay(TimeSpan.FromMilliseconds(_configuration.IterationDelayMilliseconds / _speed)).Wait();
                }
            }

            if (iterationResult == IterationResult.SolutionFound)
            {
                _isRun = false;
            }
            if (iterationResult == IterationResult.SolutionCannotBeFound)
            {
                _isRun = false;
                _executionContext.Reset();
            }
        }

        private void Button_Click_Run(object sender, RoutedEventArgs e)
        {
            _isRun = true;
            _isStepByStep = false;
        }

        private void Button_Click_Stop(object sender, RoutedEventArgs e)
        {
            _isRun = false;
        }

        private void Button_Click_NextStep(object sender, RoutedEventArgs e)
        {
            _isRun = true;
            _isStepByStep = true;
        }

        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            _executionContext.Reset();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           _speed = e.NewValue;
        }
    }
}