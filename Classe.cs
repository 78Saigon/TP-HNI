using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    public class Classe
    {

        public string nomClasse { get; set; }
        public List<string> matieres { get; set; }
        public List<Eleve> eleves { get; set; }
        

        public Classe(string Nom)
        {
            nomClasse = Nom;
            eleves = new List<Eleve>();
            matieres = new List<string>();                        
        }
             

        public void ajouterEleve(string prenom, string nom)
        {
            int tailleMaxEleve = 30;

            if (eleves.Count < tailleMaxEleve)
            {
                eleves.Add(new Eleve(prenom, nom));
            }
            else
            {
                Console.WriteLine("Nombre maximum d'élèves par classe (" + tailleMaxEleve + ") atteint");
            }
        }

        public void ajouterMatiere(string nomMatiere)
        {
            int tailleMaxMatiere = 10;                     

            if (matieres.Count < tailleMaxMatiere)
            {
                matieres.Add(nomMatiere);
            }
            else
            {
                Console.WriteLine("Nombre maximum de matières (" + tailleMaxMatiere + ") atteint");
            }
        }

        // Calcul de la moyenne de la classe dans une matière
        public float moyenneMatiere(int matiere)
        {

            if (matieres.Count == 0)
            {
                Console.WriteLine("Erreur de calcul de la moyenne de la matière pour la " + nomClasse + " : liste des matières vide.");
                return 0;
            }

            // Si la matiere n'est pas dans la liste des matières
            List<int> matieresIndex = new List<int>();

            for (int i = 0; i < matieres.Count; i++)
            {
                matieresIndex.Add(i);
            }

            if (matieresIndex.Contains(matiere) == false)
            { 
                Console.WriteLine("Erreur de calcul de la moyenne de la matière pour la " + nomClasse + " : matière inexistante.");
                return 0;
            }

            List<float> moyennesMatiere = new List<float>();
                        
            // Recolte des moyenne des élèves dans une matière dans la liste MoyennesMatiere
            foreach (Eleve eleveBoucle in eleves)
            {
                
                for (int i = 0; i < matieres.Count; i++)
                {
                    if (i == matiere)
                    {
                        moyennesMatiere.Add(eleveBoucle.moyenneMatiere(i));
                    }
                    
                }
            }

            float moyennesMatiereClasse = moyennesMatiere.Average();
            moyennesMatiere.Clear();


            try
            {
                return (float)Math.Truncate(moyennesMatiereClasse * 100) / 100;
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur de calcul de la moyenne de la matière pour la " + nomClasse);
                return 0;
            }

            
        }


        // Calcul de la moyenne générale de la classe
        public float moyenneGeneral()
        {
            List<float> moyennesClasse = new List<float>();

            if (matieres.Count == 0)
            {
                Console.WriteLine("Erreur de calcul de la moyenne générale pour la " + nomClasse + " : liste des matières vide.");
                return 0;
            }

            for (int i = 0; i < matieres.Count; i++)
            {
                moyennesClasse.Add(moyenneMatiere(i));
            }

            if (moyennesClasse.Count == 0)
            {
                Console.WriteLine("Erreur de calcul de la moyenne générale pour la " + nomClasse + " : liste des moyennes vide.");
                return 0;
            }

            try
            {
                return (float)Math.Truncate(moyennesClasse.Average() * 100) / 100;
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur de calcul de la moyenne générale pour la " + nomClasse);
                return 0;
            }

            
        }

    }
}
