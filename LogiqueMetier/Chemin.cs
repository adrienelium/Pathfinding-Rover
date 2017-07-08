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
            throw new NotImplementedException();
        }

        public List<Chemin> exploreNewChemin(Dictionary<Coordonnee, List<Vecteur>> graph)
        {
            int lastindex = listeCoor.Count - 1;
            List<Vecteur> pointAutour = graph[listeCoor[lastindex]];
        }
    }

    
}
