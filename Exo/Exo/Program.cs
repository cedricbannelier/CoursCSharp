using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo
{
    class Program
    {

        static int aleatoire()
        {
            Random rnd1 = new Random();
            return rnd1.Next(0, 2);
        }
        static void Main(string[] args)
        {

            //Variable des PV
            int pvJoueur = 0;
            int pvOrdi = 0;
            int rejouer = 0;

            do
            {
                while (pvJoueur < 5 && pvOrdi < 5)
                {
                    //On demande le choix du joueur
                    Console.WriteLine("Choisir --> 0 : pile ou 1 : face");
                    string choixJoueurString = Console.ReadLine();

                    //Conversion d'un string vers int
                    int choixJoueur = Int32.Parse(choixJoueurString);

                    //Génération d'un nombre entre 0 et 2
                    int choixOrdi = aleatoire();
                    int jetDePiece = aleatoire();

                    //Affiche choix joueur et ordi
                    Console.WriteLine("Choix jouer {0} \n Choix ordi {1} \n Choix jetDePiece {2} \n", choixJoueur, choixOrdi, jetDePiece);
                    Console.WriteLine("Score jouer {0} \n Score ordi {1} \n", pvJoueur, pvOrdi);

                    if (choixJoueur == jetDePiece && choixOrdi == jetDePiece)
                    {
                        Console.WriteLine("Egalité \n");
                    }
                    else if (choixJoueur == jetDePiece)
                    {
                        Console.WriteLine("Joueur gagne \n");
                        pvJoueur++;
                    }
                    else
                    {
                        Console.WriteLine("Ordi gagne \n");
                        pvOrdi++;
                    }
                }

                if (pvJoueur == 6)
                {
                    Console.WriteLine("*** Joueur gagne la manche ***");
                }
                else
                {
                    Console.WriteLine("*** Ordi gagne la manche ***");

                }
                Console.WriteLine("Voulez-vous rejouer ? 0 : Non ou 1 : Oui");
                string rejouerString = Console.ReadLine();
                rejouer = Int32.Parse(rejouerString);
                pvJoueur = 0;
                pvOrdi = 0;

            } while (rejouer == 1);

            //            Console.ReadKey();
        }
    }
}
