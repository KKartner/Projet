using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }

        public double RelativeStd { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            throw new NotImplementedException();
        }

        public double PercolationValue(int size)
        {
            Random aleatoire = new Random();
            Percolation grille = new Percolation(size);
            double caseOuvert = 0;
            do
            {
                int ligne = aleatoire.Next(0, size);
                int colonne = aleatoire.Next(0, size);
                grille.Open(ligne, colonne);
                caseOuvert++;
            } while (!grille.Percolate());
            return caseOuvert / (size * size);   
        }       
    }
}
