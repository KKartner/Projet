using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Statistique
    {
        public int NbComptesCreation { get; set; }
        public int NbTransaction { get; set; }
        public int NbTransactionSucces { get; set; }
        public int NbTransactionEchec { get; set; }
        public int TotalTransaction { get; set; }

        public Statistique(int nbCompte, int nbTransaction, int nbTransactionSucces, int nbTransactionEchec, int totalTransaction)
        {
            NbComptesCreation = nbCompte;
            NbTransaction = nbTransaction;
            NbTransactionSucces = nbTransactionSucces;
            NbTransactionEchec = nbTransactionEchec;
            TotalTransaction = totalTransaction;
        }
    }
}
