using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core.Models.GeneticAlgorithmBuilderModels
{
    public class GeneticAlgorithmBuilder
    {
        protected GeneticAlgorithm GeneticAlgorithm { get; } = new();
        public GeneticAlgorithm GetResult()
        {
            return GeneticAlgorithm;
        }
    }
}
