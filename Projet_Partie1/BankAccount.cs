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
        private Dictionary<string, float> historique;

        public void TransactionsAccounts(string inputFile, string transsactionFile, string outputFile)
        {
            Dictionary<string, float> comptes = CreateAccounts(inputFile);

            List<string> nbTransaction = new List<string>();
            List<float> montantTransaction = new List<float>();
            List<string> destinaite = new List<string>();
            List<string> expediteur = new List<string>();

            using (StreamReader sr = new StreamReader(transsactionFile))
            {
                string lines;
                while ((lines = sr.ReadLine()) != null)
                {
                    string[] line = lines.Split(';');
                    nbTransaction.Add(line[0]);
                    float montant = 0;
                    if (float.TryParse(line[1].Replace('.', ','), out montant))
                    {
                        montantTransaction.Add(montant);
                    }
                    destinaite.Add(line[2]);
                    expediteur.Add(line[3]);
                }
            }

            for (int i = 0; i < nbTransaction.Count; i++)
            {
                //Console.WriteLine($"{nbTransaction[i]} {montantTransaction[i]} {destinaite[i]} {expediteur[i]}");
                string sortie = "";
                sortie = nbTransaction[i];
                if (destinaite[i] == "0" && comptes.ContainsKey(expediteur[i])) // Faire Depot
                {
                    if (StockMoney(montantTransaction[i]))
                    {
                        sortie += ";OK";
                        float result = 0;
                        comptes.TryGetValue(expediteur[i], out result);
                        result += montantTransaction[i];
                        comptes[expediteur[i]] = result;
                    }
                    else
                    {
                        sortie += ";KO";
                    }
                }
                else if (expediteur[i] == "0" && comptes.ContainsKey(destinaite[i])) // Faire Retrait
                {
                    if (GiveMoney(comptes[destinaite[i]] ,montantTransaction[i]))
                    {
                        sortie += ";OK";
                        float result = 0;
                        comptes.TryGetValue(destinaite[i], out result);
                        result -= montantTransaction[i];
                        comptes[destinaite[i]] = result;
                    }
                    else
                    {
                        sortie += ";KO";
                    }
                }
                else
                {
                    float result = 0; 
                    comptes.TryGetValue(destinaite[i], out result);
                    if (result > montantTransaction[i] && montantTransaction[i] > 0 && comptes.ContainsKey(destinaite[i]) && comptes.ContainsKey(expediteur[i]))
                    {
                        sortie += ";OK";
                        float somme = 0;
                        comptes.TryGetValue(expediteur[i], out somme);
                        somme += montantTransaction[i];
                        result -= montantTransaction[i];
                        comptes[destinaite[i]] = result;
                        comptes[expediteur[i]] = somme;
                    }
                    else
                    {
                        sortie += ";KO";
                    }
                }
                using (StreamWriter sw = new StreamWriter(outputFile, true))
                {
                    sw.WriteLine(sortie);
                }
            }


        }

        public bool StockMoney(float montant)
        {
            if (montant > 0)
            {
                return true;
            }
            return false;
        }

        public bool GiveMoney(float solde, float montant)
        {
            if (montant > 0 && solde >= montant && montant <= MontantMaxTrans)
            {
                return true;
            }
            return false;
        }

        private Dictionary<string, float> CreateAccounts(string inputFile)
        {
            Dictionary<string, float> comptes = new Dictionary<string, float>();
            using (StreamReader sr = new StreamReader(inputFile))
            {
                string lines;
                while ((lines = sr.ReadLine()) != null)
                {
                    string[] line = lines.Split(';');
                    float solde = 0;
                    if (float.TryParse(line[1].Replace('.', ','), out solde))
                    {
                        if (solde >= 0 && !comptes.ContainsKey(line[0]))
                        {
                            comptes.Add(line[0], solde);
                        }
                    }
                    else
                    {
                        if (!comptes.ContainsKey(line[0]))
                        {
                            comptes.Add(line[0], 0);
                        }
                    }
                }
            }
            return comptes;
        }
    }
}
