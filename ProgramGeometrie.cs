using System;

namespace ConsoleApplication3
{
    /// <summary>
    /// Classe représentant un rectangle
    /// </summary>
    class Rectangle
    {
        #region Champs et propriétés
        /// <summary>
        /// Largeur du rectangle
        /// </summary>
        public double Largeur { get; set; }

        /// <summary>
        /// Hauteur du rectangle
        /// </summary>
        public double Hauteur { get; set; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur paramétré
        /// 
        /// Permet de créer un rectangle en spécifiant sa largeur et sa hauteur
        /// </summary>
        /// <param name="largeur">largeur que prendra le rectangle</param>
        /// <param name="hauteur">hauteur que prendra le rectangle</param>
        public Rectangle(double largeur, double hauteur)
        {
            this.Largeur = largeur;
            this.Hauteur = hauteur;
        }
        #endregion

        #region Calculs
        /// <summary>
        /// Calcul de l'aire du rectangle
        /// </summary>
        /// <returns>Aire du rectangle</returns>
        public double GetArea()
        {
            return this.Largeur * this.Hauteur;
        }

        /// <summary>
        /// Calcul du périmètre du rectangle
        /// </summary>
        /// <returns>Périmètre du rectangle</returns>
        public double GetPerimeter()
        {
            return (this.Largeur + this.Hauteur) * 2.0;
        } 
        #endregion
    }

    /// <summary>
    /// Classe permettant de représenter un triangle constitué par 3 points
    /// </summary>
    class Triangle
    {
        #region Champs et propriétés
        /// <summary>
        /// Premier point
        /// </summary>
        public Point A { get; set; }

        /// <summary>
        /// Second point
        /// </summary>
        public Point B { get; set; }

        /// <summary>
        /// Troisième point
        /// </summary>
        public Point C { get; set; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur permettant de créer un triangle à partir de 3 points
        /// </summary>
        /// <param name="a">premier point du triangle</param>
        /// <param name="b">second point du triangle</param>
        /// <param name="c">troisième point du triangle</param>
        public Triangle(Point a, Point b, Point c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }
        #endregion

        #region Calculs
        /// <summary>
        /// Calcul de l'aire du triangle
        /// </summary>
        /// <returns>aire du triangle</returns>
        public double GetArea()
        {
            return 0.5 * Math.Abs((B.X - A.X) * (C.Y - A.Y) - (C.X - A.X) * (B.Y - A.Y));
        }

        /// <summary>
        /// Calcul du périmètre du triangle
        /// </summary>
        /// <returns>Périmètre du triangle</returns>
        public double GetPerimeter()
        {
            return Point.DistanceEntreDeuxPoints(this.A, this.B) +
                Point.DistanceEntreDeuxPoints(this.B, this.C) +
                Point.DistanceEntreDeuxPoints(this.C, this.A);
        } 
        #endregion
    }

    /// <summary>
    /// Classe permettant de représenter un point
    /// </summary>
    class Point
    {
        #region Champs et propriétés
        /// <summary>
        /// Coordonnées X du point
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Coordonnées Y du point
        /// </summary>
        public double Y { get; set; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur paramétré
        /// 
        /// Permet de construire un point à partir de ses coordonnées
        /// </summary>
        /// <param name="x">coordonnée X</param>
        /// <param name="y">coordonnée Y</param>
        public Point(double x, double y)
        {
            this.Y = y;
            this.X = x;
        }

        /// <summary>
        /// Constructeur par défaut
        /// 
        /// Permet de créer un point positionné en 0,0
        /// </summary>
        public Point() : this(0, 0)
        {

        }
        #endregion

        #region Calculs
        /// <summary>
        /// Calcul de la distance entre deux points.
        /// 
        /// Cette méthode est statique car elle nécessite deux points et ne concerne pas l'un plus que l'autre.
        /// On pourrait la rendre "non statique" en utilisant qu'un seul paramètre, mais cela serait moins lisible, et pas pertinent.
        /// </summary>
        /// <param name="pA">premier point</param>
        /// <param name="pB">second point</param>
        /// <returns>distance entre les deux points</returns>
        public static double DistanceEntreDeuxPoints(Point pA, Point pB)
        {
            double dX = pA.X - pB.X;
            double dY = pA.Y - pB.Y;
            return Math.Sqrt((dX * dX) + (dY * dY));
        }
        #endregion

        #region Coordonnées polaires
        /// <summary>
        /// Exemple pas demandé :
        /// 
        /// Méthode permettant de récupérer une instance de Point créée à partir de coordonnées polaires
        /// </summary>
        /// <param name="angleEnRadians">angle en Radian</param>
        /// <param name="rayon">rayon</param>
        /// <returns>Point correspondant aux paramètres spécifiés</returns>
        public static Point APartirDeCoordonnéesPolaires(double angleEnRadians, double rayon)
        {
            //Transformation des coordonnées polaires en coordonnées carthésiennes
            double x = rayon * Math.Sin(angleEnRadians);
            double y = rayon * Math.Cos(angleEnRadians);
            return new Point(x, y);
        } 
        
        #endregion
    }

    /// <summary>
    /// Classe permettant de représenter un Disque
    /// </summary>
    class Disque
    {
        #region Champs et propriétés
        /// <summary>
        /// Rayon du disque
        /// </summary>
        public double Rayon { get; set; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur paramétré
        /// 
        /// Permet de construire un disque à partir de son rayon
        /// </summary>
        /// <param name="rayon">rayon du disque</param>
        public Disque(double rayon)
        {
            this.Rayon = rayon;
        }
        #endregion

        #region Calculs
        /// <summary>
        /// Calcul de l'aire du disque
        /// </summary>
        /// <returns>Aire du disque</returns>
        public double GetArea()
        {
            return Math.PI * Math.PI * this.Rayon;
        }

        /// <summary>
        /// Calcul du périmètre du disque
        /// </summary>
        /// <returns>Périmètre du disque</returns>
        public double GetPerimeter()
        {
            return 2.0 * Math.PI * this.Rayon;
        } 
        #endregion
    }

    /// <summary>
    /// Classe Program, responsable de la bonne exécution de l'application Console
    /// </summary>
    class Program
    {
        /// <summary>
        /// Méthode Main appelée lors du démarrage du programme
        /// </summary>
        /// <param name="args">arguments de la ligne de commande, non utilisé dans notre cas</param>
        static void Main(string[] args)
        {

            Disque monPremierDisque = new Disque(3.0);
            Console.WriteLine("Aire : {0}, Perimetre : {1}",monPremierDisque.GetArea(), monPremierDisque.GetPerimeter());

            Rectangle monRectangle = new Rectangle(2.0, 5.0);
            Console.WriteLine("Aire : {0}, Perimetre : {1}", monRectangle.GetArea(), monRectangle.GetPerimeter());

            Triangle monPremierTriangle = new Triangle(new Point(0, 0), new Point(10, 0), new Point(5, 5));
            Console.WriteLine("Aire : {0}, Perimetre : {1}", monPremierTriangle.GetArea(), monPremierTriangle.GetPerimeter());

            //Exemple de création d'un triangle à partir de points construits via des coordonnées polaires
            Point p1 = Point.APartirDeCoordonnéesPolaires(0.0, 3.0);
            Point p2 = Point.APartirDeCoordonnéesPolaires(Math.PI * 2.0 / 3.0, 3.0);
            Point p3 = Point.APartirDeCoordonnéesPolaires(Math.PI * 4.0 / 3.0, 3.0);
            Triangle monSecondTriangle = new Triangle(p1, p2, p3);
            Console.WriteLine("Aire : {0}, Perimetre : {1}", monSecondTriangle.GetArea(), monSecondTriangle.GetPerimeter());

            Console.ReadLine();
        }
    }
}