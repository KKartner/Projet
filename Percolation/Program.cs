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
            Percolation grille1 = new Percolation(6);

            bool test1 = grille1.Percolate();
            Console.WriteLine(test1);
        }
    }
}
