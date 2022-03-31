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
            //string path = Directory.GetCurrentDirectory();
            //// Fichiers entrée
            //string mngrPath = path + @"\Gestionnaires_1.txt";
            //string acctPath = path + @"\Comptes_1.txt";
            //string trxnPath = path + @"\Transactions_1.txt";
            //Fichiers sortie
            //string sttsAcctPath = path + @"\StatutOpe_1.txt";
            //string sttsTrxnPath = path + @"\StatutTra_1.txt";
            //string mtrlPath = path + @"\Metrologie_1.txt";

            //BankAccount account = new BankAccount();
            //account.TransactionsAccounts(acctPath, trxnPath, sttsPath);

            //Gestionnaire listeGestion = new Gestionnaire("", "", 0);
            //List<Gestionnaire> maListeGestionnaire = listeGestion.CreateGestionary(mngrPath);

            //List<LigneFichier> lignes = new List<LigneFichier>();
            //GetLines(acctPath, TypeFichier.Compte, lignes);
            //GetLines(trxnPath, TypeFichier.Transaction, lignes);

            //lignes = lignes.OrderBy(si => si.Date).ThenBy(si => si.Type).ToList();

            //List<string> sorties = new List<string>();
            //List<Compte> listeComptes = new List<Compte>();

            //for (int i = 0; i < lignes.Count; i++)
            //{
            //    //Console.WriteLine($"{i}: {lignes[i].Date} type: {lignes[i].Type}");

            //    string sortie = $"{lignes[i].Identifiant}";

            //    Compte nouveauCompte = new Compte(lignes[i].Identifiant, lignes[i].Date, lignes[i].Solde, "");
            //    Transaction nouvelleTransaction = new Transaction(lignes[i].Identifiant, lignes[i].Date, lignes[i].Solde, lignes[i].Entree, lignes[i].Sortie);

            //    switch (lignes[i].Type)
            //    {
            //        case TypeFichier.Compte:
            //            if (lignes[i].Entree != "0" && lignes[i].Sortie == "0") // Creation d'un compte
            //            {
            //                //Console.WriteLine($"{lignes[i].Identifiant} Creation d'un compte");
            //                if (!EstPresent(listeComptes, nouveauCompte)
            //                    && nouveauCompte.CreationCompte(maListeGestionnaire, lignes[i].Entree))
            //                {
            //                    sortie += ";OK";
            //                    nouveauCompte.Appartenance = lignes[i].Entree;
            //                    listeComptes.Add(nouveauCompte);
            //                }
            //                else
            //                {
            //                    sortie += ";KO";
            //                }

            //            }
            //            else if (lignes[i].Entree == "0" && lignes[i].Sortie != "0") // Cloture d'un compte
            //            {
            //                //Console.WriteLine($"{lignes[i].Identifiant} Cloture d'un compte");
            //                if (EstPresent(listeComptes, nouveauCompte)
            //                    && nouveauCompte.ClotureCompte(listeComptes, lignes[i].Sortie, lignes[i].Date))
            //                {
            //                    bool trouver = false;
            //                    for (int k = 0; k < listeComptes.Count; k++)
            //                    {
            //                        if (listeComptes[k].Identifiant == lignes[i].Identifiant)
            //                        {
            //                            listeComptes[k].DateCloture = lignes[i].Date;
            //                            trouver = true;
            //                            break;
            //                        }
            //                    }
            //                    if (trouver)
            //                        sortie += ";OK";
            //                    else
            //                        sortie += ";KO";
            //                }
            //                else
            //                {
            //                    sortie += ";KO";
            //                }
            //            }
            //            else if (lignes[i].Entree != "0" && lignes[i].Sortie != "0") // Changement de gestion
            //            {
            //                //Console.WriteLine($"{lignes[i].Identifiant} Changement de gestion");
            //                if (EstPresent(listeComptes, nouveauCompte)
            //                    && nouveauCompte.GestionCompte(maListeGestionnaire, lignes[i].Entree)
            //                    && nouveauCompte.GestionCompte(maListeGestionnaire, lignes[i].Sortie))
            //                {
            //                    bool trouver = false;
            //                    for (int k = 0; k < listeComptes.Count; k++)
            //                    {
            //                        if (listeComptes[k].Identifiant == lignes[i].Identifiant
            //                            && listeComptes[k].Appartenance == lignes[i].Entree
            //                            && listeComptes[k].DateCloture == DateTime.MinValue)
            //                        {
            //                            listeComptes[k].Appartenance = lignes[i].Sortie;
            //                            trouver = true;
            //                            break;
            //                        }
            //                    }
            //                    if (trouver)
            //                        sortie += ";OK";
            //                    else
            //                        sortie += ";KO";
            //                }
            //                else
            //                {
            //                    sortie += ";KO";
            //                }
            //            }
            //            else
            //            {
            //                throw new ArgumentException("Erreur: format fichier incorrect");
            //            }
            //            break;
            //        case TypeFichier.Transaction:
            //            if (lignes[i].Entree != "0" && lignes[i].Sortie == "0") // Retirer de l'argent
            //            {
            //                //Console.WriteLine($"{lignes[i].Identifiant} Retirer de l'argent");
            //                if (EstPresent(listeComptes, nouveauCompte)
            //                    && nouvelleTransaction.RetirerArgent(listeComptes, lignes[i].Sortie, lignes[i].Solde, lignes[i].Date))
            //                {
            //                    bool trouver = false;
            //                    for (int k = 0; k < listeComptes.Count; k++)
            //                    {
            //                        if (listeComptes[k].Identifiant == lignes[i].Sortie)
            //                        {
            //                            listeComptes[k].Solde += lignes[i].Solde;
            //                            trouver = true;
            //                            break;
            //                        }
            //                    }
            //                    if (trouver)
            //                        sortie += ";OK";
            //                    else
            //                        sortie += ";KO";
            //                }
            //                else
            //                {
            //                    sortie += ";KO";
            //                }
            //            }
            //            else if (lignes[i].Entree == "0" && lignes[i].Sortie != "0") // Deposer de l'argent
            //            {
            //                //Console.WriteLine($"{lignes[i].Identifiant} Deposer de l'argent");
            //                if (EstPresent(listeComptes, nouveauCompte)
            //                    && nouvelleTransaction.DeposeArgent(listeComptes, lignes[i].Sortie ,lignes[i].Solde, lignes[i].Date))
            //                {
            //                    bool trouver = false;
            //                    for (int k = 0; k < listeComptes.Count; k++)
            //                    {
            //                        if (listeComptes[k].Identifiant == lignes[i].Sortie)
            //                        {
            //                            listeComptes[k].Solde -= lignes[i].Solde;
            //                            trouver = true;
            //                            break;
            //                        }
            //                    }
            //                    if (trouver)
            //                        sortie += ";OK";
            //                    else
            //                        sortie += ";KO";
            //                }
            //                else
            //                {
            //                    sortie += ";KO";
            //                }
            //            }
            //            else if (lignes[i].Entree != "0" && lignes[i].Sortie != "0") // Virement & Prelevement
            //            {
            //                //Console.WriteLine($"{lignes[i].Identifiant} Virement & Prelevement");
            //                bool trouver = false;
            //                int indiceExpediteur = -1;
            //                int indicedestinataire = -1;
            //                for (int k = 0; k < listeComptes.Count; k++)
            //                {
            //                    if (listeComptes[k].Identifiant == nouvelleTransaction.Expediteur)
            //                    {
            //                        for (int l = 0; l < listeComptes.Count; l++)
            //                        {
            //                            if (listeComptes[l].Identifiant == nouvelleTransaction.Destinataire)
            //                            {
            //                                trouver = true;
            //                                indiceExpediteur = k;
            //                                indicedestinataire = l;
            //                            }
            //                        }
            //                    }
            //                }
            //                if (trouver)
            //                {
            //                    if (nouvelleTransaction.Montant > 0 && listeComptes[indicedestinataire].Solde > nouvelleTransaction.Montant)
            //                    {
            //                        listeComptes[indiceExpediteur].Solde += nouvelleTransaction.Montant;
            //                        listeComptes[indicedestinataire].Solde -= nouvelleTransaction.Montant;
            //                        sortie += ";OK";
            //                    }
            //                    else
            //                    {
            //                        sortie += ";KO";
            //                    }
            //                }
            //                else
            //                {
            //                    sortie += ";KO";
            //                } 
            //            }
            //            else
            //            {
            //                throw new ArgumentException("Erreur: format fichier incorrect");
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //    sorties.Add(sortie);
            //}

            //foreach (string s in sorties)
            //{
            //    Console.WriteLine(s);
            //}

            string path = Directory.GetCurrentDirectory();

            for (int n = 1; n < 7; n++)
            {
                // Fichiers entrée
                string mngrPath = path + $@"\Gestionnaires_{n}.txt";
                string acctPath = path + $@"\Comptes_{n}.txt";
                string trxnPath = path + $@"\Transactions_{n}.txt";

                List<Gestionnaire> maListeGestionnaire = CreateGestionary(mngrPath);

                List<LigneFichier> lignes = new List<LigneFichier>();
                GetLines(acctPath, TypeFichier.Compte, lignes);
                GetLines(trxnPath, TypeFichier.Transaction, lignes);

                lignes = lignes.OrderBy(si => si.Date).ThenBy(si => si.Type).ToList();

                List<string> sorties = new List<string>();
                List<Compte> listeComptes = new List<Compte>();

                for (int i = 0; i < lignes.Count; i++)
                {
                    //Console.WriteLine($"{i}: {lignes[i].Date} type: {lignes[i].Type}");

                    string sortie = $"{lignes[i].Identifiant}";

                    switch (lignes[i].Type)
                    {
                        case TypeFichier.Compte:
                            Compte nouveauCompte = new Compte(lignes[i].Identifiant, lignes[i].Date, lignes[i].Solde, "");
                            if (lignes[i].Entree != "" || lignes[i].Entree != "0" && lignes[i].Sortie == "" || lignes[i].Sortie == "0") // Creation d'un compte
                            {
                                //Console.WriteLine($"{lignes[i].Identifiant} Creation d'un compte");
                                if (!EstPresent(listeComptes, nouveauCompte)
                                    && nouveauCompte.CreationCompte(maListeGestionnaire, lignes[i].Entree))
                                {
                                    sortie += ";OK";
                                    nouveauCompte.Appartenance = lignes[i].Entree;
                                    listeComptes.Add(nouveauCompte);
                                }
                                else
                                {
                                    sortie += ";KO";
                                }

                            }
                            else if (lignes[i].Entree == "" || lignes[i].Entree == "0" && lignes[i].Sortie != "" || lignes[i].Sortie != "0") // Cloture d'un compte
                            {
                                //Console.WriteLine($"{lignes[i].Identifiant} Cloture d'un compte");
                                if (EstPresent(listeComptes, nouveauCompte)
                                    && nouveauCompte.ClotureCompte(listeComptes, lignes[i].Sortie, lignes[i].Date))
                                {
                                    bool trouver = false;
                                    for (int k = 0; k < listeComptes.Count; k++)
                                    {
                                        if (listeComptes[k].Identifiant == lignes[i].Identifiant)
                                        {
                                            listeComptes[k].DateCloture = lignes[i].Date;
                                            trouver = true;
                                            break;
                                        }
                                    }
                                    if (trouver)
                                        sortie += ";OK";
                                    else
                                        sortie += ";KO";
                                }
                                else
                                {
                                    sortie += ";KO";
                                }
                            }
                            else if (lignes[i].Entree != "" && lignes[i].Sortie != "") // Changement de gestion
                            {
                                //Console.WriteLine($"{lignes[i].Identifiant} Changement de gestion");
                                if (EstPresent(listeComptes, nouveauCompte)
                                    && nouveauCompte.GestionCompte(maListeGestionnaire, lignes[i].Entree)
                                    && nouveauCompte.GestionCompte(maListeGestionnaire, lignes[i].Sortie))
                                {
                                    bool trouver = false;
                                    for (int k = 0; k < listeComptes.Count; k++)
                                    {
                                        if (listeComptes[k].Identifiant == lignes[i].Identifiant
                                            && listeComptes[k].Appartenance == lignes[i].Entree
                                            && listeComptes[k].DateCloture == DateTime.MinValue)
                                        {
                                            listeComptes[k].Appartenance = lignes[i].Sortie;
                                            trouver = true;
                                            break;
                                        }
                                    }
                                    if (trouver)
                                        sortie += ";OK";
                                    else
                                        sortie += ";KO";
                                }
                                else
                                {
                                    sortie += ";KO";
                                }
                            }
                            else
                            {
                                throw new ArgumentException("Erreur: format fichier incorrect");
                            }
                            break;
                        case TypeFichier.Transaction:
                            Transaction nouvelleTransaction = new Transaction(lignes[i].Identifiant, lignes[i].Date, lignes[i].Solde, lignes[i].Entree, lignes[i].Sortie);
                            if (lignes[i].Entree != "" && lignes[i].Sortie == "") // Retirer de l'argent
                            {
                                //Console.WriteLine($"{lignes[i].Identifiant} Retirer de l'argent");
                                if (ExpediteurTransaction(listeComptes, nouvelleTransaction)
                                    && nouvelleTransaction.RetirerArgent(listeComptes, lignes[i].Sortie, lignes[i].Solde, lignes[i].Date))
                                {
                                    bool trouver = false;
                                    for (int k = 0; k < listeComptes.Count; k++)
                                    {
                                        if (listeComptes[k].Identifiant == lignes[i].Sortie)
                                        {
                                            listeComptes[k].Solde += lignes[i].Solde;
                                            trouver = true;
                                            break;
                                        }
                                    }
                                    if (trouver)
                                        sortie += ";OK";
                                    else
                                        sortie += ";KO";
                                }
                                else
                                {
                                    sortie += ";KO";
                                }
                            }
                            else if (lignes[i].Entree == "" && lignes[i].Sortie != "") // Deposer de l'argent
                            {
                                //Console.WriteLine($"{lignes[i].Identifiant} Deposer de l'argent");
                                if (DestinataireTransaction(listeComptes, nouvelleTransaction)
                                    && nouvelleTransaction.DeposeArgent(listeComptes, lignes[i].Sortie, lignes[i].Solde, lignes[i].Date))
                                {
                                    bool trouver = false;
                                    for (int k = 0; k < listeComptes.Count; k++)
                                    {
                                        if (listeComptes[k].Identifiant == lignes[i].Sortie)
                                        {
                                            listeComptes[k].Solde -= lignes[i].Solde;
                                            trouver = true;
                                            break;
                                        }
                                    }
                                    if (trouver)
                                        sortie += ";OK";
                                    else
                                        sortie += ";KO";
                                }
                                else
                                {
                                    sortie += ";KO";
                                }
                            }
                            else if (lignes[i].Entree != "" && lignes[i].Sortie != "") // Virement & Prelevement
                            {
                                //Console.WriteLine($"{lignes[i].Identifiant} Virement & Prelevement");
                                bool trouver = false;
                                int indiceExpediteur = -1;
                                int indicedestinataire = -1;
                                for (int k = 0; k < listeComptes.Count; k++)
                                {
                                    if (listeComptes[k].Identifiant == nouvelleTransaction.Expediteur)
                                    {
                                        for (int l = 0; l < listeComptes.Count; l++)
                                        {
                                            if (listeComptes[l].Identifiant == nouvelleTransaction.Destinataire)
                                            {
                                                trouver = true;
                                                indiceExpediteur = k;
                                                indicedestinataire = l;
                                            }
                                        }
                                    }
                                }
                                if (trouver)
                                {
                                    if (nouvelleTransaction.Montant > 0 && listeComptes[indicedestinataire].Solde > nouvelleTransaction.Montant)
                                    {
                                        listeComptes[indiceExpediteur].Solde += nouvelleTransaction.Montant;
                                        listeComptes[indicedestinataire].Solde -= nouvelleTransaction.Montant;
                                        sortie += ";OK";
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
                Console.WriteLine("");
            }

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static List<Gestionnaire> CreateGestionary(string input)
        {
            List<Gestionnaire> listeGestionnaires = new List<Gestionnaire>();
            using (StreamReader sr = new StreamReader(input))
            {
                string lines;
                while ((lines = sr.ReadLine()) != null)
                {
                    string[] line = lines.Split(';');

                    int nombreTransaction = LigneFichier.ConvertStringToInt(line[2]);
                    if (nombreTransaction != int.MinValue)
                    {
                        listeGestionnaires.Add(new Gestionnaire(line[0], line[1], nombreTransaction));
                    }
                }
            }
            return listeGestionnaires;
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

        public static bool ExpediteurTransaction(List<Compte> mesComptes, Transaction unCompte)
        {
            for (int i = 0; i < mesComptes.Count; i++)
            {
                if (mesComptes[i].Identifiant.Contains(unCompte.Expediteur))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool DestinataireTransaction(List<Compte> mesComptes, Transaction unCompte)
        {
            for (int i = 0; i < mesComptes.Count; i++)
            {
                if (mesComptes[i].Identifiant.Contains(unCompte.Destinataire))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
