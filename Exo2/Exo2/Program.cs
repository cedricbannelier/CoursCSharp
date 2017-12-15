using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo2
{
    class Program
    {
        class Personnage
        {
            public string _pseudo;
            public int _pointDeVie;
            public int _pointDeDegat;
            public int _valeurDattaque;

            public void InitPersonnage()
            {
                this._pointDeVie = 20;
                this._pointDeDegat = 4;
                this._valeurDattaque = 60;
            }
            public void PrendreDesDegats(int degat)
            {
                this._pointDeVie = this._pointDeVie - degat;
            }

        }
        static void Main(string[] args)
        {
            Random rnd1 = new Random();

            //Demande le pseudo
            Console.WriteLine("Choisir votre pseudo du personne");
            string pseudo = Console.ReadLine();

            //Instance de la class Personnage (Objet)
            Personnage personnagePrincipal = new Personnage();

            //Affecte la valer de pseudo au personnageprincipal dans _pseudo
            personnagePrincipal._pseudo = pseudo;

            //Appel de la méthode pour init les caractérisque
            personnagePrincipal.InitPersonnage();

            //Affiche les caractéristiques du personnage
            Console.WriteLine("Nom du personnage : {0}\nPoint de vie : {1}", personnagePrincipal._pseudo, personnagePrincipal._pointDeVie);
            Console.WriteLine("Point de dégat : {0}\nValeur d'attaque : {1}", personnagePrincipal._pointDeDegat, personnagePrincipal._valeurDattaque);

            Personnage personnageEnemie = new Personnage();
            personnageEnemie._pseudo = "Adrien";
            personnageEnemie.InitPersonnage();

            int jetDe = rnd1.Next(0, 101);

            do
            {
                jetDe = rnd1.Next(0, 101);
                if (jetDe <= personnagePrincipal._valeurDattaque)
                {
                    personnageEnemie.PrendreDesDegats(personnagePrincipal._pointDeDegat);
                    Console.WriteLine("{0} a touché {1}, le jet de dés a fait {2} ",personnagePrincipal._pseudo, personnageEnemie._pseudo, jetDe);
                    Console.WriteLine("{0} il te reste {1}", personnageEnemie._pseudo, personnageEnemie._pointDeVie);
                }
                else
                {
                    Console.WriteLine("{0} a loupé {1}", personnagePrincipal._pseudo, personnageEnemie._pseudo);
                }
                Console.ReadKey();
                if (personnageEnemie._pointDeVie<=0)
                {
                    break;
                }

                jetDe = rnd1.Next(0, 101);
                if (jetDe <= personnageEnemie._valeurDattaque)
                {
                    personnagePrincipal.PrendreDesDegats(personnageEnemie._pointDeDegat);
                    Console.WriteLine("{0} a touché {1}, le jet de dés a fait {2} ", personnageEnemie._pseudo, personnagePrincipal._pseudo, jetDe);
                    Console.WriteLine("{0} il te reste {1}", personnagePrincipal._pseudo, personnagePrincipal._pointDeVie);
                }
                else
                {
                    Console.WriteLine("{1} a loupé {0}", personnagePrincipal._pseudo, personnageEnemie._pseudo);
                }
                Console.ReadKey();
            } while (!(personnageEnemie._pointDeVie <= 0 || personnagePrincipal._pointDeVie <=0));






            Console.ReadKey();
        }
    }
}
