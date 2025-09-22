using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HNI_TPmoyennes
{
    // Classes fournies par HNI Institut
    public class Note
    {
        public int matiere { get; private set; }
        public float note { get; private set; }
        public Note(int m, float n)
        {
            matiere = m;
            note = n;
        }
    }

    public class Classe
    {

        public string nomClasse { get; private set; }
        public List<string> matieres { get; private set; }
        public List<Eleve> eleves { get; private set; }

        public List<float> moyennesClasse { get; private set; }          

        public Classe(string Nom)
        {
            nomClasse = Nom;
            eleves = new List<Eleve>();
            matieres = new List<string>();
            moyennesClasse = new List<float>();
        }
          

        public void ajouterEleve(string prenom, string nom)
        {
            if (eleves.Count < 30)
            { 
                eleves.Add(new Eleve(prenom, nom));
            }
            else
            {
                Console.WriteLine("Nombre maximum d'élèves par classe (30) atteint");
            }
        }

        public void ajouterMatiere(string nomMatiere)
        {
            if (matieres.Count < 10)
            {
                matieres.Add(nomMatiere);
            }
            else
            {
                Console.WriteLine("Nombre maximum de matières (10) atteint");
            }
        }   

        public float moyenneMatiere(int matiere)
        {
            var moyennesMatiereClasse = eleves.Average(e => e.moyenneMatiere(matiere));
            return (float)Math.Truncate(moyennesMatiereClasse * 100) / 100 ;
        }

        // Moyenne générale de la classe
        public float moyenneGeneral()
        {
            for (int i = 0; i < 4; i++)
            {
                moyennesClasse.Add(moyenneMatiere(i));
            }

            return (float)Math.Truncate(moyennesClasse.Average() * 100) / 100 ;
        }

    }

    public class Eleve
    {
        public List<Eleve> eleves = new();
        
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }
        public List<float> moyennes { get; set; }
        public List<string> matieres { get; private set; }

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
            this.moyennes = new List<float>();
            this.matieres = new List<string>();
        }


        public void ajouterMatiere(string nomMatiere)
        {
            if (matieres.Count < 10)
            {
                matieres.Add(nomMatiere);
            }
            else
            {
                Console.WriteLine("Nombre maximum de matières (10) atteint");
            }
        }

        public void ajouterNote(Note note)
        {
            if (notes.Count < 200)
            {
                notes.Add(note);
            }
            else
            {
                Console.WriteLine("Nombre maximum de notes (200) atteint");
            }
        }
              
        public float moyenneMatiere(int matiere) 
        {
            var notesMatiere = notes.Where(n => n.matiere == matiere).ToList();
            float notesMatierefloat = (notesMatiere.Average(n => n.note));
                 
            return (float)Math.Truncate((notesMatierefloat * 100)) / 100;
            
        }
        
        public float moyenneGeneral()
        {
           for (int i = 0; i < 4 ; i++)
           {
                moyennes.Add(moyenneMatiere(i));
           }
            
           return (float)Math.Truncate((moyennes.Average() * 100)) / 100;
            
        }
                
    }
        
}
