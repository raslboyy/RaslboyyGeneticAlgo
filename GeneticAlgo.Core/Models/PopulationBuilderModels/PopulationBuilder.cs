using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core.Models.PopulationBuilderModels
{
    public class PopulationBuilder
    {
        protected int Len { get; set; }
        protected int Size { get; set; }
        public Population GetResult()
        {
            return new Population(Size);
        }
    }
}
