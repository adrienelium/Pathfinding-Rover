using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Pathfinding
    {
        Chemin initialChemin;

        public Chemin Chemin_Le_Plus_Cours(Coordonnee start, Coordonnee finish, Dictionary<Coordonnee, List<Vecteur>> graph)
        {
            // pour un point donné (A)
            // while
            // liste les noeuds connectés -> création d'un nouveau chemin
            // je prends le chemin le plus court dans la liste créee
            // pour le chemin en cours = remplace A

            List<Chemin> listeDeChemin = new List<Chemin>();

            initialChemin = new Chemin();
            initialChemin.AddCoordonnee(start,0);
            listeDeChemin.Add(initialChemin);

            List<Chemin> resultat = new List<Chemin>();

            for (int i = 0; i < listeDeChemin.Count; i++)
            {
                Chemin chem = listeDeChemin[i];

                

                if (chem.isFinishIsReach(finish))
                {
                    resultat.Add(chem);
                    continue;
                }


                List<Chemin> newchemins = chem.exploreNewChemin(graph);

                foreach (Chemin newchem in newchemins)
                {
                    listeDeChemin.Add(newchem);
                }
            }


            return GetMinimalCheminValue(resultat);
        }

        private Chemin GetMinimalCheminValue(List<Chemin> resultat)
        {
            Chemin res;
            try
            {
                res = resultat[0];
            } catch (System.Exception)
            {
                return initialChemin;
            }
            
            foreach (Chemin chem in resultat)
            {
                if (chem.totalPonderation < res.totalPonderation)
                {
                    res = chem;
                }
            }

            return res;
        }
    }

    
}
