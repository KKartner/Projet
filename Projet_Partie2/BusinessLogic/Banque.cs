using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2.BusinessLogic
{
    public class Banque
    {
        private Dictionary<string, Gestionnaire> _gestionnaires;
        private Dictionary<string, Compte> _comptes;
        private List<Transaction> _transactions;
        private Queue<LigneFichier> _ligneFichiers;


        public Banque()
        {
            _gestionnaires = new Dictionary<string, Gestionnaire>();
            _comptes = new Dictionary<string, Compte>();
            _transactions = new List<Transaction>();
            _ligneFichiers = new Queue<LigneFichier>();
        }

        internal void CreateGestionaries(string mngrPath)
        {
            using (StreamReader sr = new StreamReader(mngrPath))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    int.TryParse(line[2], out int nombreTransaction);
                    if (nombreTransaction >= 0)
                    {
                        _gestionnaires.Add(line[0], new Gestionnaire(line[0], line[1], nombreTransaction));
                    }
                }
            }
        }

        internal void CreateFileLines(params KeyValuePair<string, TypeFichier>[] args)
        {
            List<LigneFichier> list = new List<LigneFichier>();
            foreach (KeyValuePair<string, TypeFichier> arg in args)
            {
                using (StreamReader sr = new StreamReader(arg.Key))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(';');
                        DateTime.TryParse(line[1], out DateTime date);
                        float.TryParse(line[2], out float solde);
                        list.Add(new LigneFichier(line[0], date, solde, line[3], line[4], arg.Value));
                    }
                }
            }
            _ligneFichiers = new Queue<LigneFichier>(list.OrderBy(x => x.Date).ThenBy(x => x.Type));
        }

        internal void HandleFileLines()
        {
            Metrologie metro = new Metrologie();
            List<string> statutOpe = new List<string>();
            List<string> statutTra = new List<string>();

            while (_ligneFichiers.Count > 0)
            {
                var ligneFichier = _ligneFichiers.Dequeue();
                switch (ligneFichier.Type)
                {
                    case TypeFichier.Compte:
                        //Compte nouveauCompte = new Compte(ligneFichier.Identifiant, ligneFichier.Date, ligneFichier.Solde, "");
                        statutOpe.Add($"{ligneFichier.Identifiant};{(HandleOperation(ligneFichier) ? "OK" : "KO")}");
                        break;
                    case TypeFichier.Transaction:
                        //Transaction nouvelleTransaction = new Transaction(ligneFichier.Identifiant, ligneFichier.Date, ligneFichier.Solde, ligneFichier.Entree, ligneFichier.Sortie);
                        statutTra.Add($"{ligneFichier.Identifiant};{(HandleTransaction(ligneFichier) ? "OK" : "KO")}");
                        break;
                    default:
                        break;
                }
            }
        }

        private bool HandleOperation(LigneFichier ligneFichier)
        {
            switch (GetOperationType(ligneFichier))
            {
                case TypeOperation.Ouverture:
                    if (!CompteExist(ligneFichier.Identifiant) 
                        && ligneFichier.Solde >= 0 
                        && GestionnaireExist(ligneFichier.Entree))
                    {
                        _comptes.Add(ligneFichier.Identifiant, new Compte(ligneFichier.Identifiant, ligneFichier.Date, ligneFichier.Solde, ligneFichier.Entree));
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case TypeOperation.Fermeture:
                    if (CompteExist(ligneFichier.Identifiant) 
                        && GestionnaireExist(ligneFichier.Sortie) 
                        && _comptes[ligneFichier.Identifiant].DateOuverture <= ligneFichier.Date 
                        && _comptes[ligneFichier.Identifiant].Appartenance.Equals(ligneFichier.Sortie))
                    {
                        _comptes[ligneFichier.Identifiant].DateCloture = ligneFichier.Date;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case TypeOperation.Cession:
                    if (CompteExist(ligneFichier.Identifiant) 
                        && GestionnaireExist(ligneFichier.Entree) 
                        && GestionnaireExist(ligneFichier.Sortie) 
                        && _comptes[ligneFichier.Identifiant].Appartenance.Equals(ligneFichier.Entree))
                    {
                        _comptes[ligneFichier.Identifiant].Appartenance = ligneFichier.Sortie;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }

        private bool CompteExist(string id)
        {
            return _comptes.ContainsKey(id);
        }

        private bool GestionnaireExist(string id)
        {
            return _gestionnaires.ContainsKey(id);
        }

        private TypeOperation GetOperationType(LigneFichier ligneFichier)
        {
            if (!IsBank(ligneFichier.Entree) && IsBank(ligneFichier.Sortie))
            {
                return TypeOperation.Ouverture;
            }
            else if (IsBank(ligneFichier.Entree) && !IsBank(ligneFichier.Sortie))
            {
                return TypeOperation.Fermeture;
            }
            else if (!IsBank(ligneFichier.Entree) && !IsBank(ligneFichier.Sortie))
            {
                return TypeOperation.Cession;
            }
            return (TypeOperation)int.MinValue;
        }

        private bool HandleTransaction(LigneFichier ligneFichier)
        {
            switch (GetTransactionType(ligneFichier))
            {
                case TypeTransaction.Depot:
                    if (CompteExist(ligneFichier.Identifiant) 
                        && _comptes[ligneFichier.Identifiant].DateOuverture < ligneFichier.Date 
                        && ligneFichier.Solde > 0)
                    {
                        _comptes[ligneFichier.Identifiant].Solde += ligneFichier.Solde;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case TypeTransaction.Retrait:
                    if (CompteExist(ligneFichier.Identifiant) 
                        && _comptes[ligneFichier.Identifiant].DateOuverture < ligneFichier.Date 
                        && _comptes[ligneFichier.Identifiant].Solde >= ligneFichier.Solde
                        && ligneFichier.Solde > 0 
                        && ligneFichier.Solde <= 2000)
                    {
                        _comptes[ligneFichier.Identifiant].Solde -= ligneFichier.Solde;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case TypeTransaction.Virement:
                    return false;
                default:
                    return false;
            }
        }

        private TypeTransaction GetTransactionType(LigneFichier ligneFichier)
        {
            if (!IsBank(ligneFichier.Entree) && IsBank(ligneFichier.Sortie))
            {
                return TypeTransaction.Retrait;
            }
            else if (IsBank(ligneFichier.Entree) && !IsBank(ligneFichier.Sortie))
            {
                return TypeTransaction.Depot;
            }
            else if (!IsBank(ligneFichier.Entree) && !IsBank(ligneFichier.Sortie))
            {
                return TypeTransaction.Virement;
            }
            return (TypeTransaction)int.MinValue;
        }

        private bool IsBank(string s)
        {
            return string.IsNullOrWhiteSpace(s) || s.Equals("0");
        }
    }
}
