using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01Module03
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
        static void Main(string[] args)
        {
            InitialiserDatas();

            #region AFFICHER LA LISTE DES PRENOMS DES AUTEURS DONT LE NOM COMMENCE PAR G
            //AFFICHER LA LISTE DES PRENOMS DES AUTEURS DONT LE NOM COMMENCE PAR G
            var prenomsWhereNomG = ListeAuteurs.Where(a => a.Nom.ToUpper().StartsWith("G")).Select(a => a.Prenom);
            Console.WriteLine("Afficher la liste des prenoms des auteurs dont le nom commence par G :");
            foreach (var prenom in prenomsWhereNomG)
            {
                Console.WriteLine(prenom);
            }
            Console.WriteLine();
            #endregion

            #region AFFICHER L'AUTEUR AYANT ÉCRIT LE PLUS DE LIVRES
            //AFFICHER L'AUTEUR AYANT ÉCRIT LE PLUS DE LIVRES
            Console.WriteLine("Afficher l'auteur ayant écrit le plus de livres :");
            var auteurPlusDeLivres = ListeLivres.GroupBy(a => a.Auteur).OrderByDescending(g => g.Count()).FirstOrDefault().Key;
            Console.WriteLine($"{auteurPlusDeLivres.Prenom} {auteurPlusDeLivres.Nom}");
            Console.WriteLine();

            #endregion

            #region AFFICHER LE NOMBRE MOYEN DE PAGES PAR LIVRE PAR AUTEUR
            //AFFICHER LE NOMBRE MOYEN DE PAGES PAR LIVRE PAR AUTEUR
            Console.WriteLine("Afficher le nombre moyen de pages par livre par auteur :");
            var livresParAuteur = ListeLivres.GroupBy(a => a.Auteur);
            foreach(var item in livresParAuteur)
            {
                Console.WriteLine($"{item.Key.Prenom} {item.Key.Nom} (Moyennes des pages = {item.Average(l => l.NbPages)})");
            }
            Console.WriteLine();
            #endregion

            #region AFFICHER LE TITRE DU LIVRE AVEC LE PLUS DE PAGES
            //AFFICHER LE TITRE DU LIVRE AVEC LE PLUS DE PAGES
            Console.WriteLine("Afficher le titre du livre avec le plus de pages :");
            var livrePlusDePages = ListeLivres.OrderByDescending(l => l.NbPages).FirstOrDefault();
            Console.WriteLine($"{livrePlusDePages.Titre}");
            Console.WriteLine();
            #endregion

            #region AFFICHER COMBIEN ONT GAGNÉ LES AUTEURS EN MOYENNE (MOYENNE DES FACTURES)
            //AFFICHER COMBIEN ONT GAGNÉ LES AUTEURS EN MOYENNE (MOYENNE DES FACTURES)
            Console.WriteLine("Afficher combien ont gagné les auteurs en moyenne (moyenne des factures) :");
            var facturesParAuteur = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            
            Console.WriteLine($"{facturesParAuteur}");
            Console.WriteLine();
            #endregion

            #region AFFICHER LES AUTEURS ET LA LISTE DE LEURS LIVRES
            //AFFICHER LES AUTEURS ET LA LISTE DE LEURS LIVRES
            Console.WriteLine("Afficher les auteurs et la liste de leurs livres :");
            var livresParAuteur2 = ListeLivres.GroupBy(l => l.Auteur);
            foreach(var livres in livresParAuteur2)
            {
                Console.WriteLine($"Livre par ${livres.Key.Prenom} {livres.Key.Nom} :");
                foreach(var livre in livres)
                {
                    Console.WriteLine($" - {livre.Titre}");
                }
            }
            Console.WriteLine();
            #endregion

            #region AFFICHER LES TITRES DE TOUS LES LIVRES TRIÉS PAR ORDRE ALPHABÉTIQUE
            Console.WriteLine("Afficher les titres de tous les livres triés par ordre alphabétique :");
            var livresTriParTitre = ListeLivres.OrderBy(l => l.Titre);
            foreach (var livre in livresTriParTitre)
            {
                Console.WriteLine($" - ${livre.Titre}");
            }
            Console.WriteLine();
            #endregion

            #region AFFICHER LA LISTE DES LIVRES DONT LE NOMBRE DE PAGES EST SUPÉRIEUR À LA MOYENNE
            Console.WriteLine("Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne :");
            var livresMoyennePagesSuperieurMoyenne = ListeLivres.Where(l => l.NbPages > ListeLivres.Average(a => a.NbPages));
            foreach (var livre in livresMoyennePagesSuperieurMoyenne)
            {
                Console.WriteLine($" - ${livre.Titre}");
            }
            Console.WriteLine();
            #endregion

            #region AFFICHER L'AUTEUR AYANT ÉCRIT LE MOINS DE LIVRES
            Console.WriteLine("Afficher l'auteur ayant écrit le moins de livres :");
            var auteur1 = ListeAuteurs.OrderBy(a => ListeLivres.Count(l => l.Auteur == a)).FirstOrDefault();
            Console.WriteLine($"{auteur1.Prenom} {auteur1.Nom}");
            Console.WriteLine();
            #endregion
            Console.ReadKey();
        }
}
}
