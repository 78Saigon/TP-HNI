using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HNI_TPmoyennes;

namespace HNI_TPmoyennes
{
    public class Eleve
    {
        public List<Eleve> Eleves = new();

        public string Prenom { get; private set; }
        public string Nom { get; private set; }
        public List<Note> Notes { get; private set; }
        public List<float> Moyennes { get; set; }
        
        public const int NombreMaxNotes = 200;

                        
        public Eleve(string prenom, string nom)
        {
            this.Prenom = prenom;
            this.Nom = nom;
            this.Notes = new List<Note>();
            this.Moyennes = new List<float>();
        }

        public void AjouterNote(Note note)
        {
            if (Notes.Count < NombreMaxNotes)
            {
                Notes.Add(note);
            }
            else
            {
                Console.WriteLine("Nombre maximum de notes (" + NombreMaxNotes + ") atteint");
            }
        }

        // Calcul de la moyenne par matière
        public float MoyenneMatiere(int matiere)
        {
            var notesMatiere = Notes.Where(n => n.matiere == matiere).ToList();
            float notesMatierefloat = (notesMatiere.Average(n => n.note));

            return (float)Math.Truncate((notesMatierefloat * 100)) / 100;

        }


        // Calcul de la moyenne générale à partir des moyennes des matières
        public float MoyenneGeneral()
        {
            // Ajouts des moyennes des matières dans une liste

            Classe TestClasse = new Classe("Test");
            List<string> Matieres = TestClasse.GetListeMatieres();

            var NbMatieres = new int[] { };
            
            for (int i = 0; i < Notes.Count; i++)
            {
               
            }
                                         
            for (int i = 0; i < NbMatieres ; i++)
            {
                Moyennes.Add(MoyenneMatiere(i));
            }

            if (NbMatieres == 0)
            {
                return 0;
            }
                
            return (float)Math.Truncate((Moyennes.Average() * 100)) / 100;

        }

    }
}
