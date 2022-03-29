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

            List<string> sorties = new List<string>();

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
                string sortie = "";
                sortie = nbTransaction[i];
                if (!sorties.Any(x => x.StartsWith(nbTransaction[i] + ";"))) // Verification des transactions déjà réaliser
                {
                    if (destinaite[i] == "0" && comptes.ContainsKey(expediteur[i])) // Action à réaliser: Depot
                    {
                        if (DepositeMoney(montantTransaction[i]))
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
                    else if (expediteur[i] == "0" && comptes.ContainsKey(destinaite[i])) // Action à réaliser: Retrait
                    {
                        if (TakeBackMoney(comptes[destinaite[i]], montantTransaction[i]))
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
                        // Action à réaliser: Virement et Prélèvement
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
                }
                else
                {
                    sortie += ";KO";
                }
                sorties.Add(sortie);
            }

            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                foreach (string sortie in sorties)
                {
                    sw.WriteLine(sortie);

                }
            }
        }

        public bool DepositeMoney(float montant)
        {
            if (montant > 0)
            {
                return true;
            }
            return false;
        }

        public bool TakeBackMoney(float solde, float montant)
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
