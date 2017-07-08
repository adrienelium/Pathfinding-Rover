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
            GraphGenerator gl = new GraphGenerator(5,5,0);
            displayArrayBool(gl.tabInitial);

            Pathfinding dif = new Pathfinding();
            List<Coordonnee> path = dif.shortest_path(
                new Coordonnee() { x = 0, y = 0 },
                new Coordonnee() { x = 3, y = 4 }, 
                gl.graph
                );
           
            if (path == null)
            {
                Console.WriteLine("Le path est null");
            }
            else
            {
                foreach (Coordonnee coor in path)
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
