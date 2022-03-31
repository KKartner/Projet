using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Partie2
{
    public class Gestionnaire
    {
        public string Identifiant { get; set; }
        public string Type { get; set; }
        public int NbTransaction { get; set; }

        public Gestionnaire(string identifiant, string type, int nbTransaction)
        {
            Identifiant = identifiant;
            Type = type;
            NbTransaction = nbTransaction;
        }
    }
}
