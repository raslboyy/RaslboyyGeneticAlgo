using GeneticAlgo.Core.Models.PopulationBuilderModels;
using Serilog;
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
            var X = MyRandom.GetInstance().NextDouble();
            var newC = new Chromosome(0);
            var x = 0.0;
            for (int i = 0; i < c1.Gens.Count && x < X; i++)
            {
                newC.Gens.Add(c1.Gens[i]);
                x += c1.Gens[i].X;
            }
            x = 0;
            for (int i = 0; i < c2.Gens.Count && x < 1.1; i++)
            {
                if (x >= X)
                {
                    newC.Gens.Add(c2.Gens[i]);
                }
                x += c2.Gens[i].X;
            }
            Log.Debug(newC.Gens.Count.ToString());
            return newC;
        }
    }
}
