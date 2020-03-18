﻿using System.Collections.Generic;

namespace TP01Module03
{
    public class Auteur
    {
        private List<Facture> _factures;
        public Auteur(string nom, string prenom)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            _factures = new List<Facture>();
        }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<Facture> Factures { get { return _factures; } }

        public void addFacture(Facture f)
        {
            this.Factures.Add(f);
        }
    }
}
