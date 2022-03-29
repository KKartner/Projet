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
            lignes = lignes.OrderBy(si => si.Date).ToList();
            for (int i = 0; i < lignes.Count; i++)
            {
                Console.WriteLine($"{i}: {lignes[i].Date} type: {lignes[i].Type}");
            }
            //listeCompte.CreateAccount(acctPath, maListeGestionnaire);


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

            //using (StreamReader sR = new StreamReader(path))
            //{

            //    LigneFichier ligne = new LigneFichier();
            //    lignes.Add(ligne);
            //}
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
    }
}
