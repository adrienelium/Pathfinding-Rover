using System;
using System.Collections.Generic;

namespace LogiqueMetier
{
    public class Chemin
    {
        public List<Coordonnee> listeCoor { get; set; }
        public int totalPonderation { get; set; }

        public Chemin()
        {
            listeCoor = new List<Coordonnee>();
            totalPonderation = 0;
        }

        public void AddCoordonnee(Coordonnee coor,int ponderation)
        {
            
            listeCoor.Add(coor);
            totalPonderation += ponderation;
        }

        public bool isFinishIsReach(Coordonnee finish)
        {
            bool res = false;
            foreach (Coordonnee coor in listeCoor)
            {
                if (coor.x == finish.x && coor.y == finish.y)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        public List<Chemin> exploreNewChemin(Dictionary<Coordonnee, List<Vecteur>> graph)
        {
            int lastindex = listeCoor.Count - 1;

            Coordonnee temp = listeCoor[lastindex];
            List<Vecteur> pointsAutour = graph[temp];

            List<Chemin> resChemin = new List<Chemin>();

            foreach (Vecteur vec in pointsAutour)
            {
                if (!listeCoor.Contains(vec.coor)) // Si cette coordonnée ne fait pas partie du chemin actuel
                {
                    Chemin chem = new Chemin();
                    foreach(Coordonnee coordo in listeCoor)
                    {
                        chem.AddCoordonnee(new Coordonnee { x = coordo.x, y = coordo.y }, 0);
                    }
                    chem.totalPonderation = this.totalPonderation;

                    chem.AddCoordonnee(vec.coor, vec.ponderation);
                    resChemin.Add(chem);
                }
            }

            return resChemin;
        }

    }

    
}
