using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core.Models.PopulationBuilderModels
{
    public class PopulationSizeBuilder<T> : PopulationMaxLenOfChromosomeBuilder<T>
         where T : PopulationSizeBuilder<T>
    {
        public T SetSize(int size)
        {
            Population.Size = size;
            return (T)this;
        }
    }
}
