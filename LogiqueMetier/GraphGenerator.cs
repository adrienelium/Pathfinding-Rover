﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class GraphGenerator
    {
        public bool[,] tabInitial { get; set; }
        int sizeX;
        int sizeY;
        int pourcentageObstacle;

        public Dictionary<Coordonnee, Vecteur> graph { get; set; }

        public GraphGenerator(int sizeX, int sizeY, int pourcentageObstacle)
        {
            graph = new Dictionary<Coordonnee, Vecteur>();

            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.pourcentageObstacle = pourcentageObstacle;

            generateInitialGrid();
            generateGraph();
            
        }

        private void generateInitialGrid()
        {
            tabInitial = new bool[sizeY,sizeX];
            Random rand = new Random();

            for (int i = 0; i < sizeY; i++)
            {
                for(int j = 0; j < sizeX; j++)
                {
                    if (rand.Next(0, 100) > pourcentageObstacle)
                    {
                        tabInitial[i, j] = true;
                    }
                    else
                    {
                        tabInitial[i, j] = true;
                    }
                    
                }
            }
        }

        private void generateGraph()
        {
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    if (tabInitial[i, j])
                    {
                        Coordonnee pointActuel = new Coordonnee() { x = j, y = i };

                        foreach(Vecteur vec in getNoeudAutour(pointActuel))
                        {
                            add_vertex(pointActuel, vec);
                        }
                        
                    }
                }
            }
        }

        private IEnumerable<Vecteur> getNoeudAutour(Coordonnee pointActuel)
        {
            Stack<Vecteur> stack = new Stack<Vecteur>();

            Vecteur pointGauche = getPointInformation(pointActuel,new Coordonnee() { x = pointActuel.x - 1, y = pointActuel.y });
            if (!pointGauche.obstacle)
                stack.Push(pointGauche);

            Vecteur pointDroite = getPointInformation(pointActuel, new Coordonnee() { x = pointActuel.x + 1, y = pointActuel.y });
            if (!pointDroite.obstacle)
                stack.Push(pointDroite);

            Vecteur pointHaut = getPointInformation(pointActuel, new Coordonnee() { x = pointActuel.x, y = pointActuel.y + 1 });
            if (!pointHaut.obstacle)
                stack.Push(pointHaut);

            Vecteur pointBas = getPointInformation(pointActuel, new Coordonnee() { x = pointActuel.x, y = pointActuel.y - 1 });
            if (!pointBas.obstacle)
                stack.Push(pointBas);

            return stack;
        }

        private Vecteur getPointInformation(Coordonnee pointActuel,Coordonnee pointViser)
        {
            int tempX = pointViser.x;
            int tempY = pointViser.y;

            int ponderationVec = 2;
            int nouveauPointX = tempX;
            int nouveauPointY = tempY;

            if (tempX < 0)
            {
                nouveauPointX = sizeX - 1;
                ponderationVec = 1;
            }

            if (tempY < 0)
            {
                nouveauPointY = sizeY - 1;
                ponderationVec = 1;
            }

            int maxIndexX = sizeX - 1;
            if (tempX > maxIndexX)
            {
                nouveauPointX = 0;
                ponderationVec = 1;
            }

            int maxIndexY = sizeY - 1;
            if (tempY > maxIndexY)
            {
                nouveauPointY = 0;
                ponderationVec = 1;
            }

            Coordonnee coord = new Coordonnee() { x = nouveauPointX, y = nouveauPointY };


            if (isObstacle(coord))
            {
                Vecteur vec = new Vecteur() { coor = coord, ponderation = ponderationVec, obstacle = true };
                return vec;
            }
            else
            {
                Vecteur vec = new Vecteur() { coor = coord, ponderation = ponderationVec, obstacle = false };
                return vec;
            }
        }



        private bool isObstacle(Coordonnee coor)
        {
            if (tabInitial[coor.x,coor.y])
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void add_vertex(Coordonnee name, Vecteur edges)
        {
            graph[name] = edges;
        }
    }

    public struct Coordonnee
    {
        public int x;
        public int y;
    }

    public struct Vecteur
    {
        public Coordonnee coor;
        public int ponderation;
        public bool obstacle;
    }
}
