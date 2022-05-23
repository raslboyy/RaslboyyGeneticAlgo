using GeneticAlgo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core
{
    public interface IMutationAlgorithm
    {
        void Mutate(Chromosome chromosome, double mutationAddGenCoefficient);
    }
}
