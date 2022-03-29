using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Transaction
    {
        public string Identifiant { get; set; }
        public DateTime Date { get; set; }
        public float Montant { get; set; }
        public string Expediteur { get; set; }
        public string Destinataire { get; set; }

        public Transaction(string identifiant, DateTime date, float solde, string expediteur, string destinataire)
        {
            Identifiant = identifiant;
            Date = date;
            Montant = solde;
            Expediteur = expediteur;
            Destinataire = destinataire;
        }
    }
}
