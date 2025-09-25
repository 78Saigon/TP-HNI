using System;
using System.Collections.Generic;
using System.Diagnostics;
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
      
        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();               
        }


        // Ajout d'une note
        public void ajouterNote(Note note)
        {
            const int nombreMaxNotes = 200;

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
        public float moyenneMatiere(int matiere)
        {
            List<float> notesMatiere = new List<float>();

            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].matiere == matiere)
                {
                    notesMatiere.Add(notes[i].note);      
                    // notesMatiere stocke les notes d'une matière
                }
            }

            float moyenneMatiere = notesMatiere.Average();
            notesMatiere.Clear();
                        
            return (float)Math.Truncate((moyenneMatiere * 100)) / 100;

        }

        // Calcul de la moyenne générale à partir des moyennes des matières
        public float moyenneGeneral()
        {
            List<int> listeMatieres = new List<int>();
            List<float> moyennes = new List<float>();

            // Ajout d'une note dans une liste lorsque c'est une note d'une nouvelle matière                                                                
            for (int i = 0; i < notes.Count; i++)
            {
                if (listeMatieres.Contains(notes[i].matiere) == false)
                {
                    listeMatieres.Add(notes[i].matiere);
                }
            }
                        
            int NbMatieres = listeMatieres.Count;

            if (NbMatieres == 0)
            {
                return 0;
            }

            for (int i = 0; i < NbMatieres; i++)
            {
                moyennes.Add(moyenneMatiere(i));
            }
                
            return (float)Math.Truncate((moyennes.Average() * 100)) / 100;

        }

    }
}
