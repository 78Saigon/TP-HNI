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

        public List<float> moyennesClasse { get; set; }
        public List<float> moyennesMatiere { get; set; }

        public int tailleMaxMatiere = 10;
        public int tailleMaxEleve = 30;

        public Classe(string Nom)
        {
            nomClasse = Nom;
            eleves = new List<Eleve>();
            matieres = new List<string>();
            moyennesClasse = new List<float>();
            moyennesMatiere = new List<float>();
        }
             

        public void AjouterEleve(string prenom, string nom)
        {

            if (eleves.Count < tailleMaxEleve)
            {
                eleves.Add(new Eleve(prenom, nom));
            }
            else
            {
                Console.WriteLine("Nombre maximum d'élèves par classe (" + tailleMaxEleve + ") atteint");
            }
        }

        public void AjouterMatiere(string nomMatiere)
        {

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
        public float MoyenneMatiere(int matiere)
        {
            // Recolte des moyenne des élèves dans une matière dans la liste MoyennesMatiere
            foreach (Eleve eleveBoucle in eleves)
            {
                
                for (int i = 0; i < matieres.Count; i++)
                {
                    if (i == matiere)
                    {
                        moyennesMatiere.Add(eleveBoucle.MoyenneMatiere(i));
                    }
                    
                }
            }

            float moyennesMatiereClasse = moyennesMatiere.Average();

            moyennesClasse.Add(moyennesMatiereClasse);
            // MoyennesClasse récupère les moyennes de la classe dans chaque matière

            return (float)Math.Truncate(moyennesMatiereClasse * 100) / 100;
        }

        // Calcul de la moyenne générale de la classe
        public float MoyenneGeneral()
        {
            return (float)Math.Truncate(moyennesClasse.Average() * 100) / 100;
        }

    }
}
