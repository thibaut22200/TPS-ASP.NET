﻿namespace TP01Module03
{
    public class Livre
    {
        public Livre(int id, string titre, string synopsis, Auteur auteur, int nbpages)
        {
            this.Id = id;
            this.Titre = titre;
            this.Synopsis = synopsis;
            this.Auteur = auteur;
            this.NbPages = nbpages;
        }
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Synopsis { get; set; }
        public Auteur Auteur { get; set; }
        public int NbPages { get; set; }
    }
}
