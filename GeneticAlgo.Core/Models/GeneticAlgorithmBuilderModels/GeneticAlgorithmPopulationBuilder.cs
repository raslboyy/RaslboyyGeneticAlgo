using GeneticAlgo.Core.Models.PopulationBuilderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core.Models.GeneticAlgorithmBuilderModels
{
    public class GeneticAlgorithmPopulationBuilder<T> : GeneticAlgorithmBuilder
        where T : GeneticAlgorithmPopulationBuilder<T>
    {
        void SetPopulation(PopulationBuilder populationBuilder)
        {
            GeneticAlgorithm.CurrentPopulation = populationBuilder.GetResult();
        }
    }
}
