using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie1
{
    public class BankAccount
    {
        private const int MontantMaxTrans = 1000;

        public void TransactionsAccounts(string inputFile, string transsactionFile, string outputFile)
        {
            using (StreamReader sr = new StreamReader(input))
            {
                string lines;
                while ((lines = sr.ReadLine()) != null)
                {
                    string[] line = lines.Split(';');
                    foreach (var l in line)
                    {
                        Console.WriteLine(l);
                    }
                }
            }
        }

        public bool stockMoney(int solde)
        {
            if (solde > 0)
            {
                return true;
            }
            return false;
        }

        public bool giveMoney(int solde, int montant)
        {
            if (montant > 0 && solde >= montant && montant <= MontantMaxTrans)
            {
                return true;
            }
            return false;
        }
    }
}
