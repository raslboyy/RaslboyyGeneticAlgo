using GeneticAlgo.Core.Models.PopulationBuilderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core.Models
{
    public class SimpleNextGenerationAlgorithm : INextGenerationAlgorithm
    {
        public Chromosome NextGeneration(Chromosome c1, Chromosome c2)
        {
            var len = Math.Min(c1.Gens.Count, c2.Gens.Count);
            var delimiter = MyRandom.GetInstance().Next(len);
            var newC = new Chromosome(0);
            for (int i = 0; i < delimiter; i++)
            {
                newC.Gens.Add(c1.Gens[i]);
            }
            for (int i = delimiter; i < c2.Gens.Count; i++)
            {
                newC.Gens.Add(c2.Gens[i]);
            }
            return newC;
        }
    }
}
