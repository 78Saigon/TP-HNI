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

        public string NomClasse { get; set; }
        public List<string> Matieres { get; set; }
        public List<Eleve> Eleves { get; set; }

        public List<float> MoyennesClasse { get; set; }

        public int tailleMaxMatiere = 10;
        public int tailleMaxEleve = 30;

        public Classe(string Nom)
        {
            NomClasse = Nom;
            Eleves = new List<Eleve>();
            Matieres = new List<string>();
            MoyennesClasse = new List<float>();
        }

        public List<string> GetListeMatieres()
        {
            var mc = new Classe(NomClasse);
            mc.Matieres = Matieres;
            mc.Eleves = Eleves;
            mc.MoyennesClasse = MoyennesClasse;
            return Matieres;
        }

        public void AjouterEleve(string prenom, string nom)
        {

            if (Eleves.Count < tailleMaxEleve)
            {
                Eleves.Add(new Eleve(prenom, nom));
            }
            else
            {
                Console.WriteLine("Nombre maximum d'élèves par classe (" + tailleMaxEleve + ") atteint");
            }
        }

        public void AjouterMatiere(string nomMatiere)
        {

            if (Matieres.Count < tailleMaxMatiere)
            {
                Matieres.Add(nomMatiere);
            }
            else
            {
                Console.WriteLine("Nombre maximum de matières (" + tailleMaxMatiere + ") atteint");
            }
        }

        // Calcul de la moyenne de la classe dans une matière
        public float MoyenneMatiere(int matiere)
        {
            var moyennesMatiereClasse = Eleves.Average(e => e.MoyenneMatiere(matiere));
            return (float)Math.Truncate(moyennesMatiereClasse * 100) / 100;
        }

        // Calcul de la moyenne générale de la classe
        public float MoyenneGeneral()
        {
            // Ajout des moyennes de la classe par matière dans une liste
            for (int i = 0; i < Matieres.Count; i++)
            {
                MoyennesClasse.Add(MoyenneMatiere(i));
            }

            return (float)Math.Truncate(MoyennesClasse.Average() * 100) / 100;
        }

    }
}
