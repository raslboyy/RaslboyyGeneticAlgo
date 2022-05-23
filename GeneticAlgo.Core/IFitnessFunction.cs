using GeneticAlgo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo.Core
{
    public interface IFitnessFunction
    {
        double Calculate(Chromosome chromosome);
    }
}
