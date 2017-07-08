using System;
using System.Collections.Generic;

namespace LogiqueMetier
{
    public class Chemin
    {
        List<Coordonnee> listeCoor = new List<Coordonnee>();
        public int totalPonderation { get; set; }

        public Chemin()
        {
            totalPonderation = 0;
        }

        public void AddCoordonnee(Coordonnee coor,int ponderation)
        {
            listeCoor.Add(coor);
            totalPonderation += ponderation;
        }

        public bool isFinishIsReach(Coordonnee finish)
        {
            return listeCoor.Contains(finish);
        }

        public List<Chemin> exploreNewChemin(Dictionary<Coordonnee, List<Vecteur>> graph)
        {
            int lastindex = listeCoor.Count - 1;
            List<Vecteur> pointsAutour = graph[listeCoor[lastindex]];

            List<Chemin> resChemin = new List<Chemin>();

            foreach (Vecteur vec in pointsAutour)
            {
                if (!listeCoor.Contains(vec.coor)) // Si cette coordonnée ne fait pas partie du chemin actuel
                {
                    Chemin chem = this;
                    chem.AddCoordonnee(vec.coor, vec.ponderation);
                    resChemin.Add(chem);
                }
            }

            return resChemin;
        }
    }

    
}
