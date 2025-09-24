using System;
using System.Collections.Generic;
using System.Linq;
using HNI_TPmoyennes;


namespace HNI_TPmoyennes
{
    class Program
    {
        static void Main(string[] args)
        {

            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.AjouterEleve("Jean", "RAGE");
            sixiemeA.AjouterEleve("Paul", "HAAR");
            sixiemeA.AjouterEleve("Sibylle", "BOQUET");
            sixiemeA.AjouterEleve("Annie", "CROCHE");
            sixiemeA.AjouterEleve("Alain", "PROVISTE");
            sixiemeA.AjouterEleve("Justin", "TYDERNIER");
            sixiemeA.AjouterEleve("Sacha", "TOUILLE");
            sixiemeA.AjouterEleve("Cesar", "TICHO");
            sixiemeA.AjouterEleve("Guy", "DON");
            // Ajout de matières étudiées par la classe
            sixiemeA.AjouterMatiere("Francais");
            sixiemeA.AjouterMatiere("Anglais");
            sixiemeA.AjouterMatiere("Physique/Chimie");
            sixiemeA.AjouterMatiere("Histoire");
            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sixiemeA.eleves[ieleve].AjouterNote(new Note(matiere, (float)((6.5 +
                        random.NextDouble() * 34)) / 2.0f));

                        // Note minimale = 3
                    }
                }
            }


            Eleve eleve = sixiemeA.eleves[4];
            // Afficher la moyenne d'un élève dans une matière
            Console.WriteLine(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[3] + " : " +
            eleve.MoyenneMatiere(3) + "\n");
            Console.WriteLine(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[2] + " : " +
            eleve.MoyenneMatiere(2) + "\n");
            Console.WriteLine(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            eleve.MoyenneMatiere(1) + "\n");
            Console.WriteLine(eleve.prenom + " " + eleve.nom + ", Moyenne en " + sixiemeA.matieres[0] + " : " +
            eleve.MoyenneMatiere(0) + "\n");
            // Afficher la moyenne générale du même élève
            Console.WriteLine(eleve.prenom + " " + eleve.nom + ", Moyenne Generale : " + eleve.MoyenneGeneral() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.WriteLine("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[3] + " : " +
            sixiemeA.MoyenneMatiere(3) + "\n");
            Console.WriteLine("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[2] + " : " +
            sixiemeA.MoyenneMatiere(2) + "\n");
            Console.WriteLine("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[1] + " : " +
            sixiemeA.MoyenneMatiere(1) + "\n");
            Console.WriteLine("Classe de " + sixiemeA.nomClasse + ", Moyenne en " + sixiemeA.matieres[0] + " : " +
            sixiemeA.MoyenneMatiere(0) + "\n");
            // Afficher la moyenne générale de la classe
            Console.WriteLine("Classe de " + sixiemeA.nomClasse + ", Moyenne Generale : " + sixiemeA.MoyenneGeneral() + "\n");
            Console.Read();
        }
    }
}



