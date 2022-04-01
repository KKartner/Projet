using Projet_Partie2.BusinessLogic;
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

            for (int n = 1; n < 7; n++)
            {
                // Fichiers entrée
                string mngrPath = path + $@"\Gestionnaires_{n}.txt";
                string acctPath = path + $@"\Comptes_{n}.txt";
                string trxnPath = path + $@"\Transactions_{n}.txt";
                // Fichiers sortie
                string sttsAcctPath = path + $@"\StatutOpe_{n}.txt";
                string sttsTrxnPath = path + $@"\StatutTra_{n}.txt";
                string mtrlPath = path + $@"\Metrologie_{n}.txt";

                Banque b = new Banque();
                b.CreateGestionaries(mngrPath);
                b.CreateFileLines(new KeyValuePair<string, TypeFichier>[]
                {
                    new KeyValuePair<string, TypeFichier>(acctPath, TypeFichier.Compte),
                    new KeyValuePair<string, TypeFichier>(trxnPath, TypeFichier.Transaction)
                });

                b.HandleFileLines();

                /**
                for (int i = 0; i < lignes.Count; i++)
                {
                    string sortie = $"{lignes[i].Identifiant}";
                    switch (lignes[i].Type)
                    {
                        case TypeFichier.Transaction:
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
                                    if (nouvelleTransaction.Montant > 0
                                        && listeComptes[indicedestinataire].Solde > nouvelleTransaction.Montant
                                        && listeComptes[indicedestinataire].HistoriqueCompte(listeComptes[indicedestinataire], lignes[i].Solde, lignes[i].Date))
                                    {
                                        listeComptes[indiceExpediteur].Solde += nouvelleTransaction.Montant;
                                        listeComptes[indicedestinataire].Solde -= nouvelleTransaction.Montant;
                                        listeComptes[indicedestinataire].HistoriqueDateTransaction.Add(lignes[i].Date);
                                        listeComptes[indicedestinataire].HistoriqueSommeTransaction.Add(lignes[i].Solde);
                                        sommeTotalTransaction += nouvelleTransaction.Montant;
                                        sortie += ";OK";
                                        nombreTotalTransSucces++;
                                    }
                                    else
                                    {
                                        sortie += ";KO";
                                        nombreTotalTransEchec++;
                                    }
                                }
                                else
                                {
                                    sortie += ";KO";
                                    nombreTotalTransEchec++;
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
                **/
            }

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
