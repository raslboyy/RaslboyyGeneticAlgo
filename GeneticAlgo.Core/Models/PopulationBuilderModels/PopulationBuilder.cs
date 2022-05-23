using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core.Models.PopulationBuilderModels
{
    public class PopulationBuilder
    {
        private readonly MyRandom _random = MyRandom.GetInstance();
        protected Population Population { get; } = new ();
        public Population GetResult()
        {
            for (int i = 0; i < Population.Size; i++)
            {
                Population.Chromosomes.Add(new Chromosome(_random.Next(1, Population.MaxLenOfChromosome + 1)));
            }
            return Population;
        }
    }
}
