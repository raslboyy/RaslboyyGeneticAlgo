using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core.Models
{
    public class SimpleMutationAlgorithm : IMutationAlgorithm
    {
        public void Mutate(Chromosome chromosome, double mutationAddGenCoefficient)
        {
            var i = MyRandom.GetInstance().Next() % (int)(chromosome.Size * (1 + mutationAddGenCoefficient));
            if (i < chromosome.Size) 
            {
                chromosome.Gens[i] = chromosome.Gens[i].Mutate();
            }
            else
            {
                chromosome.Gens.Add(new Gen());
            }
        }
    }
}
