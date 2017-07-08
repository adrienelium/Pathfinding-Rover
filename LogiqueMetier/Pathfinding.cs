using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Pathfinding
    {


        public List<Coordonnee> shortest_path(Coordonnee start, Coordonnee finish, Dictionary<Coordonnee, Vecteur> graph)
        {
            // pour un point donné (A)
            // while
            // liste les noeuds connectés -> création d'un nouveau chemin
            // je prends le chemin le plus court dans la liste créee
            // pour le chemin en cours = remplace A

            List<Chemin> listeDeChemin = new List<Chemin>();

            
            
            
        }
    }

    public class Chemin
    {
        List<Coordonnee> listeCoor = new List<Coordonnee>();

        public void AddCoordonnee(Coordonnee coor)
        {
            listeCoor.Add(coor);
        }
    }

    public class EnsembleDeChemin
    {
        List<Chemin> listeChemin = new List<Chemin>();

        public void AddChemin(Chemin chem)
        {
            listeChemin.Add(chem);
        }

        public void RemoveChemin(Chemin chem)
        {
            listeChemin.Remove(chem);
        }

        public Chemin GetMinimalCheminValue()
        {
            Dictionary<Chemin, int> dico = new Dictionary<Chemin, int>();
            Dictionary<Chemin, int> dicoddd = dico.OrderByDescending<Chemin,int>;

            foreach (Chemin chem in listeChemin)
            {

            }
        }
    }
}
