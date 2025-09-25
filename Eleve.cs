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
        
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }
        public List<float> moyennes { get; set; }
        public List<float> notes2 { get; set; }
        
        public const int nombreMaxNotes = 200;

                        
        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
            this.moyennes = new List<float>();
            this.notes2 = new List<float>();

        }


        // Ajout d'une note
        public void AjouterNote(Note note)
        {
            if (notes.Count < nombreMaxNotes)
            {
                notes.Add(note);     
                // Notes stocke toutes les notes de l'élève
            }
            else
            {
                Console.WriteLine("Nombre maximum de notes (" + nombreMaxNotes + ") atteint");
            }
        }

        // Calcul de la moyenne par matière
        public float MoyenneMatiere(int matiere)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].matiere == matiere)
                {
                    notes2.Add(notes[i].note);      
                    // Notes2 stocke les notes d'une matière
                }
            }

            float moyenneMatiere = notes2.Average();
            moyennes.Add(moyenneMatiere);
            
            return (float)Math.Truncate((moyenneMatiere * 100)) / 100;

        }

        // Calcul de la moyenne générale à partir des moyennes des matières
        public float MoyenneGeneral()
        {
 
            if (moyennes.Count == 0)
            {
                return 0;
            }
                
            return (float)Math.Truncate((moyennes.Average() * 100)) / 100;

        }

    }
}
