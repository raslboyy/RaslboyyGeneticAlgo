using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core.Models.PopulationBuilderModels
{
    public class PopulationMaxLenOfChromosomeBuilder<T> : PopulationBuilder
         where T : PopulationMaxLenOfChromosomeBuilder<T>
    {
        public T SetMaxLenOfChromosome(int len)
        {
            Len = len;
            return (T)this;
        }
    }
}
