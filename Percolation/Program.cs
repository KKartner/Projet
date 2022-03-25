using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            PercolationSimulation simulation = new PercolationSimulation();
            simulation.PercolationValue(6);
            Console.WriteLine(simulation);
        }
    }
}
