using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace relationsEntreClasses
{
    class Program
    {
        static void reponseSeTouche(bool seTouche)
        {
            if (seTouche)
            {
                Console.WriteLine("Ils se touchent");
            }
            else
            {
                Console.WriteLine("Ils ne se touchent pas");
            }
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
/*
            public double X;
            public double Y;
            public Point()
            {
            }

            public Point(double posX, double posY)
            {
                this.X = posX;
                this.Y = posY;
            }
*/
            public static double distanceEntreDeuxPoints(Point a, Point b)
            {
                return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            }
        }
        class Triangle
        {
            public Point pA { get; set; }
            public Point pB { get; set; }
            public Point pC { get; set; }
/*            public Triangle()
            {
                this.pA = new Point();
                this.pB = new Point();
                this.pC = new Point();
            }
*/            public Triangle(Point premierPoint, Point secondPoint, Point troisiemePoint)
            {
                this.pA = premierPoint;
                this.pB = secondPoint;
                this.pC = troisiemePoint;
            }
            public Triangle(int paX, int paY, int pbX, int pbY, int pcX, int pcY)
            {
                this.pA = new Point(paX, paY);
                this.pB = new Point(pbX, pbY);
                this.pC = new Point(pcX, pcY);
            }
            public double GetArea()
            {
                return 0.5 * (Math.Abs((pB.X - pA.X) * (pC.Y - pA.Y) - (pC.X - pA.X) * (pB.Y - pA.Y)));
            }
            public double GetPerimeter()
            {
                return Math.Sqrt(Math.Pow(pA.X - pB.X, 2) + Math.Pow(pA.Y - pB.Y, 2));
            }
        }
        class Rectangle
        {
            public Point pA { get; set; }
            public Point pB { get; set; }

            //Constructeur avec des valeurs
/*            public Rectangle()
            {
                this.pA = new Point();
                this.pB = new Point();
            }
*/            public double GetArea()
            {
                double largeur = Math.Abs(pA.X - pB.X);
                double hauteur = Math.Abs(pA.Y - pB.Y);
                return largeur * hauteur;
            }
             public double GetPerimeter()
            {
                double perimetre = 2 * (Math.Abs(pA.X - pB.X) * Math.Abs(pA.Y - pB.Y));
                return perimetre;
            }
        }
        static void Main(string[] args)
        {
            Triangle nouveauTriangle = new Triangle(5,10,10,15,7,20);

            nouveauTriangle.pA.X = 5;
            nouveauTriangle.pA.Y = 10;
            nouveauTriangle.pB.X = 10;
            nouveauTriangle.pB.Y = 15;
            nouveauTriangle.pC.X = 7;
            nouveauTriangle.pC.Y = 20;


            Console.WriteLine("Aire du triangle {0}", nouveauTriangle.GetArea());
            Console.WriteLine("Périmètre du triangle {0}", nouveauTriangle.GetPerimeter());

            Rectangle nouveauRectangle = new Rectangle();

            nouveauRectangle.pA.X = 3;
            nouveauRectangle.pA.Y = 3;

            Console.WriteLine("Aire du rectangle {0}", nouveauRectangle.GetArea());
            Console.WriteLine("Périmètre du rectangle {0}", nouveauRectangle.GetPerimeter());

            Console.WriteLine("---------------------");

            Disque disque1 = new Disque();
            disque1.rayon = 5;
            disque1.centre.X = 0;
            disque1.centre.Y = 0;

            Disque disque2 = new Disque();
            disque2.rayon = 10;
            disque2.centre.X = 0;
            disque2.centre.Y = 20;

            reponseSeTouche(Disque.disqueTouche(disque1, disque2)); 

            Console.ReadKey();

        }
    }
}
