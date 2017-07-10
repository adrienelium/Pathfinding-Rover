using LogiqueMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Affichage_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphGenerator gl = new GraphGenerator(20,20,15);
            displayArrayBool(gl.tabInitial);

            Console.WriteLine("Nombre Total de Noeud : " + gl.graph.Count);
            foreach (KeyValuePair<Coordonnee, List<Vecteur>> obj in gl.graph)
            {
                Console.WriteLine("Le point X=" + obj.Key.x + " , Y=" + obj.Key.y);

                foreach (Vecteur vec in obj.Value)
                {
                    Console.WriteLine("Est relier au point X=" + vec.coor.x + " , Y=" + vec.coor.y + " avec une pondération de " + vec.ponderation);
                }

                Console.WriteLine();
            }

            Pathfinding dif = new Pathfinding();
            Chemin path = dif.Chemin_Le_Plus_Cours(
                new Coordonnee() { x = 0, y = 0 },
                new Coordonnee() { x = 15, y = 10 }, 
                gl.graph
                );

           
           
            if (path == null)
            {
                Console.WriteLine("Le path est null test");
            }
            else
            {
                foreach (Coordonnee coor in path.listeCoor)
                {
                    Console.WriteLine("Point : X=" + coor.x + " , Y=" + coor.y);
                }
            }

            

            Console.ReadLine();
        }

        static void displayArrayBool(bool[,] arr)
        {

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
