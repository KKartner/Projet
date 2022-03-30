using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            // Fichiers entrée
            string mngrPath = path + @"\Gestionnaires_1.txt";
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            //Fichiers sortie
            string sttsAcctPath = path + @"\StatutOpe_1.txt";
            string sttsTrxnPath = path + @"\StatutTra_1.txt";
            string mtrlPath = path + @"\Metrologie_1.txt";

            //BankAccount account = new BankAccount();
            //account.TransactionsAccounts(acctPath, trxnPath, sttsPath);

            Gestionnaire listeGestion = new Gestionnaire("", "", 0);
            List<Gestionnaire> maListeGestionnaire = listeGestion.CreateGestionary(mngrPath);

            List<LigneFichier> lignes = new List<LigneFichier>();
            GetLines(acctPath, TypeFichier.Compte, lignes);
            GetLines(trxnPath, TypeFichier.Transaction, lignes);

            lignes = lignes.OrderBy(si => si.Date).ThenBy(si => si.Type).ToList();

            List<string> sorties = new List<string>();
            List<Compte> listeComptes = new List<Compte>();

            for (int i = 0; i < lignes.Count; i++)
            {
                //Console.WriteLine($"{i}: {lignes[i].Date} type: {lignes[i].Type}");

                string sortie = "";
                sortie += i;

                switch (lignes[i].Type)
                {
                    case TypeFichier.Compte:
                        Compte nouveauCompte = new Compte(lignes[i].Identifiant, lignes[i].Date, lignes[i].Solde);

                        if (lignes[i].Entree != "0" && lignes[i].Sortie == "0") // Creation d'un compte
                        {
                            Console.WriteLine("Creation d'un compte");
                            if (!EstPresent(listeComptes, nouveauCompte))
                            {
                                if (nouveauCompte.CreationCompte(maListeGestionnaire, lignes[i].Entree))
                                {
                                    sortie += ";OK";
                                    listeComptes.Add(nouveauCompte);
                                }
                                else
                                {
                                    sortie += ";KO";
                                }
                            }
                            else
                            {
                                sortie += ";KO";
                            }
                            
                        }
                        else if (lignes[i].Entree == "0" && lignes[i].Sortie != "0") // Cloture d'un compte
                        {
                            Console.WriteLine("Cloture d'un compte");
                        }
                        else if (lignes[i].Entree != "0" && lignes[i].Sortie != "0") // Changement de gestion
                        {
                            Console.WriteLine("Changement de gestion");
                        }
                        else
                        {
                            throw new ArgumentException("Erreur: format fichier incorrect");
                        }
                        break;
                    case TypeFichier.Transaction:
                        Transaction nouvelleTransaction = new Transaction(lignes[i].Identifiant, lignes[i].Date, lignes[i].Solde, lignes[i].Entree, lignes[i].Sortie);

                        if (lignes[i].Entree != "0" && lignes[i].Sortie == "0") // Retirer de l'argent
                        {
                            Console.WriteLine("Retirer de l'argent");
                        }
                        else if (lignes[i].Entree == "0" && lignes[i].Sortie != "0") // Deposer de l'argent
                        {
                            Console.WriteLine("Deposer de l'argent");
                        }
                        else if (lignes[i].Entree != "0" && lignes[i].Sortie != "0") // Virement & Prelevement
                        {
                            Console.WriteLine("Virement & Prelevement");
                        }
                        else
                        {
                            throw new ArgumentException("Erreur: format fichier incorrect");
                        }
                        break;
                    default:
                        break;
                }
                sorties.Add(sortie);
            }

            foreach (string s in sorties)
            {
                Console.WriteLine(s);
            }


            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void GetLines(string path, TypeFichier type, List<LigneFichier> lignes)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string lines;
                while ((lines = sr.ReadLine()) != null)
                {
                    string[] line = lines.Split(';');
                    float monSolde = ConvertStringToFloat(line[2]);
                    DateTime dateCreation = Convert.ToDateTime(line[1]);
                    LigneFichier ligne = new LigneFichier(line[0], dateCreation, monSolde, line[3], line[4], type);
                    lignes.Add(ligne);
                }
            }
        }

        public static float ConvertStringToFloat(string StringConvert)
        {
            float convertion = int.MinValue;
            if (float.TryParse(StringConvert.Replace('.', ','), out convertion))
            {
                return convertion;
            }
            return convertion;
        }

        public static bool EstPresent(List<Compte> mesComptes, Compte unCompte)
        {
            for (int i = 0; i < mesComptes.Count; i++)
            {
                if (mesComptes[i].Identifiant.Contains(unCompte.Identifiant))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
